using System;
using System.Windows;
using GalaxyCreator.Model;
using GalaxyCreator.ViewModel;
using Microsoft.Win32;

namespace GalaxyCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            MainData.CreateSecotorGrid(sectorCanvas, 20, 20, 75);


        }

        private void sectorCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            ((MainViewModel)DataContext).CanvasClicked(e);

        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Load Json";
            if (openFileDialog.ShowDialog() == true)
            {
                ((MainViewModel)DataContext).ReadJson(openFileDialog.FileName);
                MessageBox.Show("Galaxy has been loaded", "Load Galaxy Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            // Only if a galaxy object actually exist
            if (((MainViewModel)DataContext).galaxyExist())
            {  
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save Json";
                saveFileDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog.FileName != "")
                {
                    ((MainViewModel)DataContext).SaveJson(saveFileDialog.FileName);
                    MessageBox.Show("Galaxy has been saved", "Save Galaxy Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else
            {
                MessageBox.Show("There is no galaxy loaded", "Save Galaxy Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

}