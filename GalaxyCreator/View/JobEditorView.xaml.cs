using System.Windows.Controls;

namespace GalaxyCreator.View
{
    /// <summary>
    /// Interaction logic for JobEditorView.xaml
    /// </summary>
    public partial class JobEditorView : UserControl
    {
        public JobEditorView()
        {
            InitializeComponent();
        }

        private void JobDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems != null && e.AddedItems.Count > 0)
            {
                JobDataGrid.ScrollIntoView(e.AddedItems[0]);
            }
        }
    }
}
