using GalaxyCreator.Model;
using GalaxyCreator.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GalaxyCreator.View
{
    /// <summary>
    /// Interaction logic for MapEditorView.xaml
    /// </summary>
    public partial class MapEditorView : UserControl
    {

        public MapEditorView()
        {

            InitializeComponent();

            /* TODO: NEED TO CREATE THIS WHEN DATA IS LOADED OR A NEW MAPO IS CREATED */
            MainData.SetCanvas(sectorCanvas);//, 20, 20, 75);

            ScaleTransform st = new ScaleTransform();
            st.ScaleY = -1;

            sectorCanvas.RenderTransform = st;


            sectorCanvas.MouseWheel += (sender, e) =>
            {
            //    zoom += zoomSpeed * e.Delta;

            //    if ( zoom < zoomMin)
            //    {
            //        zoom = zoomMin;
            //    }

            //    if ( zoom > zoomMax)
            //    {
            //        zoom = zoomMax;
            //    }

            //    Point mousePos = e.GetPosition(sectorCanvas);

            //    if (zoom > 1)
            //    {
            //        st = new ScaleTransform(zoom, zoom *-1, mousePos.X, mousePos.Y);
            //    }
            //    else
            //    {
            //        st = new ScaleTransform(zoom, zoom *-1);
            //    }

            //    sectorCanvas.RenderTransform = st;
            //    st.ScaleY = -1;

                if (e.Delta > 0)
                {
                    st.ScaleX *= 0.9;
                    st.ScaleY *= 0.9;
                }
                else
                {
                    st.ScaleX /= 0.9;
                    st.ScaleY /= 0.9;
                }

             };

            this.Loaded += MapEditorView_Loaded;
           
        }

        private void MapEditorView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((MapEditorViewModel)DataContext).DrawGalaxyMap();
        }



        /* UNABLE TO MVVM THIS FOR REASONS */
        private void sectorCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MapEditorViewModel)DataContext).CanvasClicked(e);
        }
    }
}
