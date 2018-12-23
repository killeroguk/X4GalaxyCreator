using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model.Json
{
    public class Cluster
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Music { get; set; }
        public String Sunlight { get; set; }
        public String Economy { get; set; }
        public String Security { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public String Backdrop { get; set; }
        public bool NoBelts { get; set; } = false;
        public Faction FactionHq { get; set; }
        public FactionStart FactionStart { get; set; }
        public ObservableCollection<Connection> Connections { get; set; }
        public ObservableCollection<Belt> Belts { get; set; }
        public ObservableCollection<Station> Stations { get; set; }
        public ObservableCollection<SpaceObject> SpaceObjects { get; set; }

        /* VARIBLES/FUNCTIONS USED MY THE EDITOR */
        [JsonIgnore]
        public Guid UId { get; set; }
        [JsonIgnore]
        public Polygon Polygon { get; set; }
        //public Hex Hex { get; set; }
        [JsonIgnore]
        public bool IsEnabled { get; set; }
        public int Polygon_MouseLeftButtonDown { get; }

        public Cluster(int x, int y, double hexSize, bool newCluster)
        {
            UId = Guid.NewGuid();
            X = x;
            Y = y;

            Connections = new ObservableCollection<Connection>();
            Belts = new ObservableCollection<Belt>();
            Stations = new ObservableCollection<Station>();
            SpaceObjects = new ObservableCollection<SpaceObject>();

            //Hex = new Hex(x, y, 75, UId);

            if (newCluster == true)
                IsEnabled = false;
            else
                IsEnabled = true;

            double OuterRadius = 75;
            double InnerRadius = OuterRadius * 0.866025404f;

            var corners = new PointCollection()
            {
                new Point(OuterRadius *0.5f,InnerRadius),
                new Point(OuterRadius *-0.5f,InnerRadius),
                new Point(-OuterRadius, 0F),
                new Point(OuterRadius *-0.5f,-InnerRadius),
                new Point(OuterRadius *0.5f,-InnerRadius),
                new Point(OuterRadius, 0F),
            };

            int shiftedY = (-Y) + 10;
            int shiftedX = X + 10;

            Console.WriteLine($"Creating Hex X:{x}/{shiftedX} Y:{y}/{shiftedY}");

            Polygon = new Polygon();
            Polygon.Tag = UId;
            Polygon.Stroke = Brushes.Black;

            if ( IsEnabled)
                Polygon.Fill = Brushes.Pink;
            else
                Polygon.Fill = Brushes.LightGray;

            Polygon.StrokeThickness = 1;
            Polygon.HorizontalAlignment = HorizontalAlignment.Center;
            Polygon.VerticalAlignment = VerticalAlignment.Center;
            Polygon.Points = corners;


            double a = (shiftedY + (shiftedX / 2) - (shiftedX * 0.5f));
            double b = (InnerRadius * 2f);

            double aa = (shiftedX / 2);
            double aaa = (shiftedX * 0.5f);


            double yPos = a * b + OuterRadius;

            Console.WriteLine($"a: {a}, b: {b}, yPos: {yPos} - aa: {aa}, aaa: {aaa}");

            Polygon.RenderTransform = new TranslateTransform((shiftedX * (OuterRadius * 1.5f) + OuterRadius), yPos);// ((shiftedY + shiftedX * 0.5f - shiftedX / 2) * (InnerRadius * 2f)) + OuterRadius);
        }


    }


}
