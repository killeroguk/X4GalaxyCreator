using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;

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
            MainData.CreateMapGalaxy(Galaxy, 20, 20, 75);
            MainViewModel vm = (App.Current.Resources["Locator"] as ViewModelLocator).Main;
            vm.MainContainer = new MapEditorViewModel(Galaxy);
        }
    }
}
