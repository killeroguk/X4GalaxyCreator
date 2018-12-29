using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GalaxyCreator.Model
{

    public class CanvasChildObject
    {
        public UIElement UIElement { get; set; }
        public int ZIndex { get; set; }
        public double X { get; set; }
        public double Y { get; set; }


        public CanvasChildObject(UIElement uIElement, int zIndex, double x, double y )
        {
            UIElement = uIElement;
            ZIndex = zIndex;
            X = x;
            Y = y;
        }
    }

    public class CanvasBaseObject
    {
        private  UIElement UIElement { get; set; }
        private List<CanvasChildObject> Children { get; set; }

        private int ZIndex { get; set; }

        public CanvasBaseObject(UIElement element, int zIndex)
        {
            UIElement = element;
            ZIndex = zIndex;

            Children = new List<CanvasChildObject>();
        }

        public void AddChild (UIElement uIElement, int zIndex, double x, double y)
        {
            CanvasChildObject canvasChildObject = new CanvasChildObject(uIElement, zIndex, x, y);
            Children.Add(canvasChildObject);
        }

        public void DrawObject(Canvas canvas)
        {
            canvas.Children.Add(UIElement);
            Canvas.SetZIndex(UIElement, ZIndex);

            foreach (CanvasChildObject child in Children)
            {
                Canvas.SetZIndex(child.UIElement, child.ZIndex);
                Canvas.SetLeft(child.UIElement, child.X);
                Canvas.SetTop(child.UIElement, child.Y);
                canvas.Children.Add(child.UIElement);
   
            }

        }

        public void ClearObject(Canvas canvas)
        {
            canvas.Children.Remove(UIElement);

            foreach (CanvasChildObject child in Children)
            {
                canvas.Children.Remove(child.UIElement);
            }
        }

    }
}
