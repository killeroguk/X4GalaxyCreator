using GalaxyCreator.Model;
using GalaxyCreator.ViewModel;
using System.Windows.Controls;

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
            MainData.CreateSecotorGrid(sectorCanvas, 20, 20, 75);
        }

        private void sectorCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MapEditorViewModel)DataContext).CanvasClicked(e);
        }
    }
}
