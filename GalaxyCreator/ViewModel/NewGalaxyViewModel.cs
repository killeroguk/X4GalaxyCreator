using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using GalaxyCreator.ViewModel.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GalaxyCreator.ViewModel
{
    public class NewGalaxyViewModel : ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly GalaxyValidator _galaxyValidator;
        public Galaxy Galaxy { get; set; } = new Galaxy();
        public bool DefaultEconomy { get; set; } = false;
        public bool DefaultJobs { get; set; } = false;

        private RelayCommand _saveCommand = null;
        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        /** wrapping each property for validation possibilities **/

        public long Seed { get { return Galaxy.Seed;  } set { Galaxy.Seed = value; RaisePropertyChanged("Seed"); } }
        public String GalaxyName { get { return Galaxy.GalaxyName; } set { Galaxy.GalaxyName = value; RaisePropertyChanged("GalaxyName"); } }
        public String GalaxyPrefix { get { return Galaxy.GalaxyPrefix; } set { Galaxy.GalaxyPrefix = value; RaisePropertyChanged("GalaxyPrefix"); } }
        public GalaxyOptions GalaxyOptions { get { return Galaxy.GalaxyOptions; } set { Galaxy.GalaxyOptions = value; RaisePropertyChanged("GalaxyOptions"); } }
        public String Description { get { return Galaxy.Description; } set { Galaxy.Description = value; RaisePropertyChanged("Description"); } }
        public String Author { get { return Galaxy.Author; } set { Galaxy.Author = value; RaisePropertyChanged("Author"); } }
        public String Version { get { return Galaxy.Version; } set { Galaxy.Version = value; RaisePropertyChanged("Version"); } }
        public String Date { get { return Galaxy.Date; } set { Galaxy.Date = value; RaisePropertyChanged("Date"); } }
        public String Save { get { return Galaxy.Save; } set { Galaxy.Save = value; RaisePropertyChanged("Save"); } }
        public int MinRandomBelts { get { return Galaxy.MinRandomBelts; } set { Galaxy.MinRandomBelts = value; RaisePropertyChanged("MinRandomBelts"); } }
        public int MaxRandomBelts { get { return Galaxy.MaxRandomBelts; } set { Galaxy.MaxRandomBelts = value; RaisePropertyChanged("MaxRandomBelts"); } }

        public NewGalaxyViewModel() {
            this._saveCommand = new RelayCommand(() => OnSaveClicked());
            _galaxyValidator = new GalaxyValidator();
        }

        private void OnSaveClicked()
        {
            if (!HasErrors())
            {
                if (DefaultJobs)
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultJson\DefaultJobs.json");
                    ObservableCollection<Job> jobs = JsonConvert.DeserializeObject<ObservableCollection<Job>>(File.ReadAllText(path));
                    Galaxy.Jobs = jobs;
                }

                if (DefaultEconomy)
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DefaultJson\DefaultProducts.json");
                    ObservableCollection<Product> products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(File.ReadAllText(path));
                    Galaxy.Products = products;
                }

                MainData.CreateMapGalaxy(Galaxy, 20, 20, 75);
                MainViewModel vm = (App.Current.Resources["Locator"] as ViewModelLocator).Main;
                vm.Galaxy = Galaxy;
                vm.MainContainer = new MapEditorViewModel(Galaxy);
                vm.ClearCurrentFilename();
                vm.GalaxyExistPropertyChanged("GalaxyExist");
            }
        }

        public string this[string columnName]
        {
            get
            {
                if(Galaxy != null)
                {
                    var firstOrDefault = _galaxyValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                    if (firstOrDefault != null)
                        return _galaxyValidator != null ? firstOrDefault.ErrorMessage : "";
                }
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_galaxyValidator != null)
                {
                    var results = _galaxyValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        private bool HasErrors()
        {
            return Error != string.Empty;
        }
    }
}
