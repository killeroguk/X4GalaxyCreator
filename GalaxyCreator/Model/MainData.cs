using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{
    public class CanvasElement
    {

        public CanvasElementType Type { get; set; }
        public Shape Shape { get; set; }
        public bool isDirty { get; set; }

        public string UId { get; set; }

        public CanvasElement(CanvasElementType type, Shape shape, string uId)
        {
            Type = type;
            Shape = shape;
            UId = uId;

        }

    }

    public static class MainData
    {
        public  static List<CanvasElement> canvasElements = new List<CanvasElement>();

        private static Galaxy MapGalaxy;

        public static Canvas Canvas;

        public static Cluster SelectedMapCluster;


        public static void CreateMapGalaxy(Galaxy galaxy, int rowCount, int columnCount, double hexSize)
        {
            MapGalaxy = galaxy;
            GenerateEmptySectors(MapGalaxy, rowCount, columnCount, hexSize);            
        }

        public static void GenerateEmptySectors(Galaxy galaxy, int rowCount, int colCount, double hexSize)
        {
            int x = -(rowCount / 2);
            int y = -(colCount / 2);
            int clusteridCounter = 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (((List<Cluster>)galaxy.Clusters).FirstOrDefault(c => c.X == x && c.Y == y) == null)
                    {
                        Console.WriteLine("Creating hex at pos X: " + x + ", Y: " + y);
                        Cluster cluster = new Cluster(x, y, hexSize, true, clusteridCounter);
                        galaxy.Clusters.Add(cluster);
                        clusteridCounter++;
                    }
                    else
                    {
                        Console.WriteLine("Not creating hex at pos X: " + x + ", Y: " + y);
                    }
                    y++;
                }
                y = -(colCount / 2);
                x++;
            }
        }

        public static void SetGalaxyMap( Galaxy galaxy)
        {
            MapGalaxy = galaxy;
        }

        public static Galaxy GetGalaxyMap()
        {
            return MapGalaxy;
        }


        public static void AddChildToCanvas(CanvasElementType type, Shape child, string UId)
        {
            CanvasElement canvasElement = new CanvasElement(type, child, UId);
            canvasElements.Add(canvasElement);


            child.Uid = UId;
            Canvas.Children.Add(child);

            if (type == CanvasElementType.CONNECTION)
            {
                Canvas.SetZIndex(child, 10);
            }
            else
            {
                Canvas.SetZIndex(child, 0);
            }
        }

        public static void RemoveConnectionFromCanvas(CanvasConnection connection)
        {
            Canvas.Children.Remove(connection.Line);

            MapGalaxy.CanvasConnections.Remove(connection);
        }


        public static void SetCanvas(Canvas canvas)
        {
            Canvas = canvas;
        }


        public static CanvasElementType GetShapeType(Shape shape)
        {
            var foundShape = canvasElements.FirstOrDefault(s => s.Shape == shape);

            if (foundShape != null)
                return foundShape.Type;

            return CanvasElementType.unknown;

        }

        public static void UpdateCanvas()
        {
            if (Canvas == null)
                return;

            //Application.Current.Dispatcher.Invoke((Action)delegate {
            //    canvas.Children.Clear();
            //});

            //Application.Current.Dispatcher.Invoke((Action)delegate
            //{
            //foreach (CanvasElement element in canvasElements)
            //{
            //    if (element.isDirty)
            //        canvas.Children[canvas.Children.IndexOf(element.Shape)].InvalidateMeasure();
            //}


                //foreach (Shape shape in canvas.Children)
                //{
                //    shape.Fill = Brushes.Red;
                //    shape.InvalidateMeasure();
                //}
            //});


            //foreach (CanvasDrawingElement element in canvasDrawingElements)
            //{
            //    Application.Current.Dispatcher.Invoke((Action)delegate {


            //        CreateShape(element);
            //    });
               
            //}
            
        }


    }
}
