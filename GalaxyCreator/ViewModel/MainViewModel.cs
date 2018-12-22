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
using Microsoft.Win32;

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

        private int _rowCount;
        private int _columnCount;

        private RelayCommand _newGalaxyClickedCommand;
        private RelayCommand _loadFileClickedCommand;
        private RelayCommand _saveFileClickedCommand;
        private RelayCommand _mapEditorClickedCommand;
        private RelayCommand _jobEditorClickedCommand;

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
            MainData.SetGalaxyMap(Galaxy);

            Galaxy.GenerateEmptySectors(Galaxy, 20, 20, 75);


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
            //MainContainer = new MapEditorViewModel(Galaxy);
        }

        private void NewGalaxyClicked()
        {
            MainData.CreateMapGalaxy(20, 20, 75);
            MainContainer = new MapEditorViewModel(Galaxy);
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

                MessageBox.Show("Galaxy has been loaded", "Load Galaxy Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveFileClicked()
        {
            // Only if a galaxy object actually exist
            if (GalaxyExist())
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save Json";
                saveFileDialog.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog.FileName != "")
                {
                    SaveJson(saveFileDialog.FileName);
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

        private void MapEditorClicked()
        {
            MainContainer = new MapEditorViewModel(Galaxy);
        }

        private void JobEditorClicked()
        {
            MainContainer = new JobEditorViewModel(Galaxy);
        }

    }
}