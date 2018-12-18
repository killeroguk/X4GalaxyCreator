using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{




    public class CanvasElement
    {

        public CanvasElementType type { get; set; }
        public Shape shape { get; set; }

    }


    public static class MainData
    {

        private static List<CanvasDrawingElement> canvasDrawingElements = new List<CanvasDrawingElement>();

        private static SectorGrid sectorGrid;

        public static Canvas canvas;

        public static void CreateSecotorGrid(Canvas sectorCanvas, int rowCount, int columnCount, int size)
        {
            canvas = sectorCanvas;
            sectorGrid = new SectorGrid(sectorCanvas, rowCount, columnCount, size);
        }

        public static SectorGrid GetSectorGrid()
        {
            return sectorGrid;
        }



        public static Shape CreateShape(CanvasDrawingElement canvasDrawingElement)
        {

            switch (canvasDrawingElement.ElementDrawingType)
            {
                case CanvasDrawingElementType.polygon:
                    {

                        var element = (CanvasPolygonElement)canvasDrawingElement;

                        Polygon polygon = new Polygon();
                        polygon.Tag = element.Tag;
                        polygon.Stroke = element.StrokeBrush;
                        polygon.Fill = element.FillBrush;
                        polygon.StrokeThickness = element.StrokeThickness;
                        polygon.HorizontalAlignment = HorizontalAlignment.Center;
                        polygon.VerticalAlignment = VerticalAlignment.Center;

                        polygon.Points = element.Points;

                        polygon.RenderTransform = element.TranslateTransform;

                        canvas.Children.Add(polygon);

                        canvasDrawingElement.Shape = polygon;

                        return polygon;
                    }
            }

            return null;


        }

        public static void AddShapeToList(CanvasDrawingElement canvasDrawingElement)
        {

            CreateShape(canvasDrawingElement);
            canvasDrawingElements.Add(canvasDrawingElement);

        }

        public static CanvasElementType GetShapeType(Shape shape)
        {
            var foundShape = canvasDrawingElements.FirstOrDefault(s => s.Shape == shape);

            if (foundShape != null)
                return foundShape.ElementType;

            return CanvasElementType.unknown;

        }

        public static void UpdateCanvas()
        {
            canvas.Children.Clear();

            foreach (CanvasDrawingElement element in canvasDrawingElements)
            {
                CreateShape(element);
            }
        }


    }
}
