using System.Windows.Controls;

namespace GalaxyCreator.View
{
    /// <summary>
    /// Interaction logic for EconomyEditorView.xaml
    /// </summary>
    public partial class EconomyEditorView : UserControl
    {
        public EconomyEditorView()
        {
            InitializeComponent();
        }

        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                ProductDataGrid.ScrollIntoView(e.AddedItems[0]);
            }
        }
    }
}
