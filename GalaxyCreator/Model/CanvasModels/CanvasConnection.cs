using GalaxyCreator.Model.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model.CanvasModel
{
    public class CanvasConnection
    {
        public Guid UId { get; set; }
        public string ConnectionId1 { get; set; }
        public ConnectionType Connection1Type { get; set; }

        public string ConnectionId2 { get; set; }
        public ConnectionType Connection2Type { get; set; }

        public Line Line { get; set; }

        public CanvasConnection(string connectionId1, string connectionId2, ConnectionType connection1Type)
        {
            ConnectionId1 = connectionId1;
            ConnectionId2 = connectionId2;
            Connection1Type = connection1Type;

            switch (connection1Type)
            {
                case ConnectionType.N:
                    {
                        Connection2Type = ConnectionType.S;
                        break;
                    }
                case ConnectionType.NE:
                    {
                        Connection2Type = ConnectionType.SW;
                        break;
                    }
                case ConnectionType.NW:
                    {
                        Connection2Type = ConnectionType.SE;
                        break;
                    }
                case ConnectionType.S:
                    {
                        Connection2Type = ConnectionType.N;
                        break;
                    }
                case ConnectionType.SE:
                    {
                        Connection2Type = ConnectionType.NW;
                        break;
                    }
                case ConnectionType.SW:
                    {
                        Connection2Type = ConnectionType.NE;
                        break;
                    }
            }

            UId = Guid.NewGuid();


        }

        public void GenerateLine()
        {
            Point cluster1Pos = MainData.GetGalaxyMap().Clusters.First(c => c.Id == ConnectionId1).Polygon.TransformToAncestor(MainData.Canvas).Transform(new Point(0, 0));
            Point cluster2Pos = MainData.GetGalaxyMap().Clusters.First(c => c.Id == ConnectionId2).Polygon.TransformToAncestor(MainData.Canvas).Transform(new Point(0, 0));

            Console.WriteLine("1: " + cluster1Pos.ToString());

            cluster1Pos = GetPoint(cluster1Pos, 55, Connection1Type);
            cluster2Pos = GetPoint(cluster2Pos, 55, Connection2Type);

            Line = new Line();
            Line.X1 = cluster1Pos.X;
            Line.Y1 = cluster1Pos.Y;
            Line.X2 = cluster2Pos.X;
            Line.Y2 = cluster2Pos.Y;


            Line.Stroke = Brushes.Orange;
            Line.StrokeThickness = 5;
            Line.Tag = UId;

            MainData.AddChildToCanvas(CanvasElementType.CONNECTION, Line, UId.ToString());
        }


        private Point GetPoint(Point center, float radius, ConnectionType connectionType)
        {
            double angle = 0.0;

            switch (connectionType)
            {
                case ConnectionType.N:
                    angle = 90;
                    break;
                case ConnectionType.NW:
                    angle = 30;
                    break;
                case ConnectionType.NE:
                    angle = 150;
                    break;
                case ConnectionType.S:
                    angle = 270;
                    break;
                case ConnectionType.SW:
                    angle = 330;
                    break;
                case ConnectionType.SE:
                    angle = 210;
                    break;
            }

            double rad = angle * Math.PI / 180.0;

            return new Point((center.X + radius * Math.Cos(rad)), (center.Y + radius * Math.Sin(rad)));
        }
    }
}
