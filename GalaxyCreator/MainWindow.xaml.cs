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
        }

        /* UNABLE TO MVVM THIS FOR REASONS */
        private void sectorCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MainViewModel)DataContext).CanvasClicked(e);
        }

    }

}