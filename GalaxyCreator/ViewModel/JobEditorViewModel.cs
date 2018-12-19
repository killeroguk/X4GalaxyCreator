using GalaSoft.MvvmLight;
using GalaxyCreator.Model.Json;

namespace GalaxyCreator.ViewModel
{
    class JobEditorViewModel : ViewModelBase
    {
        private Galaxy galaxy;

        public JobEditorViewModel(Galaxy galaxy)
        {
            this.galaxy = galaxy;
        }
    }
}
