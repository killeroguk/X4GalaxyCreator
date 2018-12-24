using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace GalaxyCreator.ViewModel
{
    public class NewGalaxyViewModel : ViewModelBase
    {
        public Galaxy Galaxy { get; set; } = new Galaxy();
        public bool DefaultEconomy { get; set; } = false;
        public bool DefaultJobs { get; set; } = false;

        private RelayCommand _saveCommand = null;
        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        public NewGalaxyViewModel() {
            this._saveCommand = new RelayCommand(() => OnSaveClicked());
        }

        private void OnSaveClicked()
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
        }
    }
}
