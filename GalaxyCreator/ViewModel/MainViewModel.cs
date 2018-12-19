using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.ViewModel.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GalaxyCreator.ViewModel
{

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IMainDataService _mainDataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        private List<Sector> _sectors;
        private int _rowCount;
        private int _columnCount;

        private RelayCommand<MouseButtonEventArgs> _canvasClickedCommand;

        private Object _rightHandViewModel;
        private Object _mainContainer;

        private Model.Json.Galaxy Galaxy;

        public Object MainContainer
        {
            get { return _mainContainer; }
            set
            {
                Set(ref _mainContainer, value);
            }
        }

        public Object RightHandViewModel
        {
            get { return _rightHandViewModel; }
            set
            {
                Set(ref _rightHandViewModel, value);
            }
        }

        internal void ReadJson(string fileName)
        {
            Galaxy = JsonConvert.DeserializeObject<Model.Json.Galaxy>(File.ReadAllText(fileName));
            Console.WriteLine(Galaxy.GalaxyName);
        }

        internal void SaveJson(string fileName)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@fileName))
            {
                LowercaseJsonSerializer.Serialize(file, Galaxy);
            }
        }

        internal bool GalaxyExist()
        {
            return Galaxy != null;
        }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public void SwitchToJobEditor(RoutedEventArgs e)
        {
            MainContainer = new JobEditorViewModel(Galaxy);
        }

        public void SwitchToMapEditor(RoutedEventArgs e)
        {
            MainContainer = new MapEditorViewModel(Galaxy);
        }

        public List<Sector> Sectors
        {
            get
            {
                return _sectors;
            }
            set
            {
                Set(ref _sectors, value);
            }
        }

        public int RowCount
        {
            get
            {
                return _rowCount;
            }
            set
            {
                Set(ref _rowCount, value);
            }
        }

        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
            set
            {
                Set(ref _columnCount, value);
            }
        }


        public RelayCommand<MouseButtonEventArgs> CanvasClickedCommand
        {
            get
            {
                if (_canvasClickedCommand == null)
                {
                    _canvasClickedCommand = new RelayCommand<MouseButtonEventArgs>((e) => CanvasClicked(e));
                }

                return _canvasClickedCommand;
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, IMainDataService mainDataService)
        {

            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            //RightHandViewModel = new GalaxyEditViewModel();
            MainContainer = new MapEditorViewModel(Galaxy);
        }


        public void CanvasClicked(MouseButtonEventArgs e)
        {

            /* TODO: SOME HOW CHECK WHAT WAS CLICKED ON */

            /* CHECK TO SEE IF A SHAPE HAS BEEN CLICKED ON OR THE CANVAS ITS SELF */
            if (e.Source.GetType() != typeof(Canvas))
            {
                CanvasElementType selectedCanvasType = MainData.GetShapeType((Shape)e.Source);

                switch (selectedCanvasType)
                {
                    case CanvasElementType.sector:
                        {
                            SectorGrid grid = MainData.GetSectorGrid();
                            Sector selectedSector = grid.Sectors.Find(s => s.Id == (Guid)((Polygon)e.Source).Tag);

                            RightHandViewModel = new SectorEditViewModel(selectedSector);
                            break;
                        }
                }
            }
            else
            {
                RightHandViewModel = new GalaxyEditViewModel();
            }
          

            
        }

    }
}