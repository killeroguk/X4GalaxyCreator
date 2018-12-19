using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GalaxyCreator.Model
{

    public enum CanvasElementType
    {
        CLUSTER,
        unknown
    }

    public enum CanvasDrawingElementType
    {
        polygon
    }
    public class CanvasDrawingElement
    {
        public CanvasElementType ElementType;
        public CanvasDrawingElementType ElementDrawingType;

        public SolidColorBrush StrokeBrush;
        public SolidColorBrush FillBrush;
        public int StrokeThickness;
        public object Tag;

        public Shape Shape;

        public TranslateTransform TranslateTransform;

    }

    public class CanvasPolygonElement: CanvasDrawingElement
    {
        

        public PointCollection Points;

        public CanvasPolygonElement(CanvasElementType elementType, PointCollection points, SolidColorBrush strokeBrush, SolidColorBrush fillBrush,int strokeThickness,object tag, TranslateTransform translateTransform )
        {
            ElementType = elementType;

            ElementDrawingType = CanvasDrawingElementType.polygon;

            Points = points;
            StrokeBrush = strokeBrush;
            FillBrush = fillBrush;
            StrokeThickness = strokeThickness;
            Tag = tag;
            TranslateTransform = translateTransform; 
        }
    }
}
