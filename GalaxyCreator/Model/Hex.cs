using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{
    public class Hex
    {
        public PointCollection corners;

        public CanvasDrawingElement canvasElement;

        public Polygon polygon { get; set; }

        public int X;
        public int Y;
        double OuterRadius;
        double InnerRadius;

        public Hex(int x, int y, double size, Guid id)
        {
            X = x;
            Y = y;

            OuterRadius = size;
            InnerRadius = OuterRadius * 0.866025404f;

            corners = new PointCollection()
            {
                new Point(OuterRadius *0.5f,InnerRadius),
                new Point(OuterRadius *-0.5f,InnerRadius),
                new Point(-OuterRadius, 0F),
                new Point(OuterRadius *-0.5f,-InnerRadius),
                new Point(OuterRadius *0.5f,-InnerRadius),
                new Point(OuterRadius, 0F),
            };

            polygon = new Polygon();
            polygon.Tag = id;
            polygon.Stroke = Brushes.Black;
            polygon.Fill = Brushes.LightGray;
            polygon.StrokeThickness = 1;
            polygon.HorizontalAlignment = HorizontalAlignment.Center;
            polygon.VerticalAlignment = VerticalAlignment.Center;
            polygon.Points = corners;
            polygon.MouseLeftButtonDown += Polygon_MouseLeftButtonDown;
            polygon.RenderTransform = new TranslateTransform((Y * (OuterRadius * 1.5f) + OuterRadius), ((X + Y * 0.5f - Y / 2) * (InnerRadius * 2f)) + OuterRadius);

        }


        private void Polygon_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Polygon polygon = (Polygon)sender;
            
            //throw new NotImplementedException();
        }
    }
}
