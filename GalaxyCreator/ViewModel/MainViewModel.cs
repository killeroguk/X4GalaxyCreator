using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.ViewModel.Util;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using GalaxyCreator.Model.Json;
using System.Linq;
using System.Windows.Media;
using GalaxyCreator.Util;
using System.Reflection;

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
        private string _currentFileName = string.Empty;

        private int _rowCount;
        private int _columnCount;

        private RelayCommand _newGalaxyClickedCommand;
        private RelayCommand _loadFileClickedCommand;
        private RelayCommand _saveAsFileClickedCommand;
        private RelayCommand _saveFileClickedCommand;
        private RelayCommand _mapEditorClickedCommand;
        private RelayCommand _jobEditorClickedCommand;
        private RelayCommand _economyEditorClickedCommand;
        private RelayCommand _exitClickedCommand;
        private RelayCommand _createModClickedCommand;
        private RelayCommand _helpClickedCommand;

        private Object _rightHandViewModel;
        private Object _mainContainer;

        public Galaxy Galaxy { get; set; }

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
            /* IF WE ALREADY HAVE A GALAXY LOADED WE NEED TO CLEAR IT */
            Galaxy = null;
            MainData.SetGalaxyMap(null);

            MainContainer = null;

            /* CLEAR ANY STUFF ON THE CANVAS IF THERE IS ANY */
            if ( MainData.Canvas != null)
                MainData.Canvas.Children.Clear();

            /* CLEAR THE CANVAS ELEMENT LIST */
            MainData.canvasElements.Clear();


            _currentFileName = fileName;
            Galaxy = JsonConvert.DeserializeObject<Model.Json.Galaxy>(File.ReadAllText(fileName));
            MainData.SetGalaxyMap(Galaxy);

            /*Process the loaded sectors - need to see what race owns what sector */
            foreach (Cluster cluster in Galaxy.Clusters)
            {
                ClusterHelperFunctions.ChooseClusterFillColour(cluster);
                if (cluster.FactionStart.Faction != Faction.PLAYER)
                {
                    cluster.GameStart = true;
                }

                foreach (Connection con in cluster.Connections)
                {

                    MainData.GetGalaxyMap().CanvasConnections.Add(new CanvasConnection(con.TargetClusterId, cluster.Id,con.ConnectionType));
                }
               
            }

            MainData.GenerateEmptySectors(Galaxy, 20, 20, 75);
        }

        private void SaveToFile()
        {
            using (StreamWriter file = File.CreateText(@_currentFileName))
            {
                LowercaseJsonSerializer.Serialize(file, Galaxy);
            }
        }

        internal void GalaxyExistPropertyChanged(string v)
        {
            RaisePropertyChanged("GalaxyExist");
        }

        internal void SaveAsJson(string fileName)
        {
            // serialize JSON directly to a file
            _currentFileName = fileName;
            SaveToFile();
        }

        internal void SaveJson()
        {
            SaveToFile();
        }

        public bool GalaxyExist
        {
            get { return Galaxy != null; }
        }

        public void ClearCurrentFilename()
        {
            _currentFileName = string.Empty;
            RaisePropertyChanged("FileNameSet");
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

        public RelayCommand NewGalaxyClickedCommand
        {
            get
            {
                if (_newGalaxyClickedCommand == null)
                {
                    _newGalaxyClickedCommand = new RelayCommand(() => NewGalaxyClicked());
                }

                return _newGalaxyClickedCommand;
            }
        }

        public RelayCommand LoadFileClickedCommand
        {
            get
            {
                if (_loadFileClickedCommand == null)
                {
                    _loadFileClickedCommand = new RelayCommand(() => LoadFileClicked());
                }

                return _loadFileClickedCommand;
            }
        }

        public RelayCommand SaveAsFileClickedCommand
        {
            get
            {
                if (_saveAsFileClickedCommand == null)
                {
                    _saveAsFileClickedCommand = new RelayCommand(() => SaveAsFileClicked());
                }

                return _saveAsFileClickedCommand;
            }
        }

        public RelayCommand SaveFileClickedCommand
        {
            get
            {
                if (_saveFileClickedCommand == null)
                {
                    _saveFileClickedCommand = new RelayCommand(() => SaveFileClicked());
                }

                return _saveFileClickedCommand;
            }
        }

        public RelayCommand CreateModClickedCommand
        {
            get
            {
                if (_createModClickedCommand == null)
                {
                    _createModClickedCommand = new RelayCommand(() => CreateModClicked());
                }

                return _createModClickedCommand;
            }
        }

        public RelayCommand MapEditorClickedCommand
        {
            get
            {
                if (_mapEditorClickedCommand == null)
                {
                    _mapEditorClickedCommand = new RelayCommand(() => MapEditorClicked());
                }

                return _mapEditorClickedCommand;
            }
        }

        public RelayCommand JobEditorClickedCommand
        {
            get
            {
                if (_jobEditorClickedCommand == null)
                {
                    _jobEditorClickedCommand = new RelayCommand(() => JobEditorClicked());
                }

                return _jobEditorClickedCommand;
            }
        }

        public RelayCommand EconomyEditorClickedCommand
        {
            get
            {
                if (_economyEditorClickedCommand == null)
                {
                    _economyEditorClickedCommand = new RelayCommand(() => EconomyEditorClicked());
                }

                return _economyEditorClickedCommand;
            }
        }

        public RelayCommand ExitClickedCommand
        {
            get
            {
                if (_exitClickedCommand == null)
                {
                    _exitClickedCommand = new RelayCommand(() => ExitClicked());
                }

                return _exitClickedCommand;
            }
        }

        public RelayCommand HelpClickedCommand
        {
            get
            {
                if (_helpClickedCommand == null)
                {
                    _helpClickedCommand = new RelayCommand(() => HelpClicked());
                }

                return _helpClickedCommand;
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
        }

        public bool FileNameSet
        {
            get { return _currentFileName != string.Empty; }
        }

        private void NewGalaxyClicked()
        {
            //MainData.CreateMapGalaxy(20, 20, 75);
            MainContainer = new NewGalaxyViewModel();
        }

        private void LoadFileClicked()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.Title = "Load Json";

            if (openFileDialog.ShowDialog() == true)
            {
                ReadJson(openFileDialog.FileName);

                /* TODO: THIS JSON THEN NEEDS TO BE USED BY THE GALAXY EDTIOR SOME HOW */
                RaisePropertyChanged("FileNameSet");
                RaisePropertyChanged("GalaxyExist");
                //MainContainer = new MapEditorViewModel(Galaxy);
                MessageBox.Show("Galaxy has been loaded", "Load Galaxy Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveAsFileClicked()
        {
            // Only if a galaxy object actually exist
            if (GalaxyExist)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save Json";
                saveFileDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog.FileName != "")
                {
                    SaveAsJson(saveFileDialog.FileName);
                    RaisePropertyChanged("FileNameSet");
                    MessageBox.Show("Galaxy has been saved", "Save Galaxy Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("There is no galaxy loaded", "Save Galaxy Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveFileClicked()
        {
            // Only if a galaxy object actually exist and the filename is set
            if (GalaxyExist && _currentFileName != string.Empty)
            {
                    SaveJson();
                    MessageBox.Show("Galaxy has been saved", "Save Galaxy Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("There is no galaxy loaded", "Save Galaxy Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateModClicked()
        {
            try
            {
                string jar = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Generator\universe-generator-1.3.jar");
                JavaExecutor.execute(jar, _currentFileName);
                MessageBox.Show("Mod has been created", "Mod Creation Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Mod Creation Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MapEditorClicked()
        {
            if (MainContainer != null)
                ((ViewModelBase)MainContainer).Cleanup();

            MainContainer = new MapEditorViewModel(Galaxy);
        }

        private void JobEditorClicked()
        {
            if (MainContainer != null)
                ((ViewModelBase)MainContainer).Cleanup();

            MainContainer = new JobEditorViewModel(Galaxy);
        }

        private void EconomyEditorClicked()
        {
            if (MainContainer != null)
                ((ViewModelBase)MainContainer).Cleanup();

            MainContainer = new EconomyEditorViewModel(Galaxy);
        }

        private void ExitClicked()
        {
            if (MainContainer != null)
                ((ViewModelBase)MainContainer).Cleanup();

            System.Windows.Application.Current.Shutdown();
        }

        private void HelpClicked()
        {
            if (MainContainer != null)
                ((ViewModelBase)MainContainer).Cleanup();

            MainContainer = new HelpViewModel();
        }
    }
}