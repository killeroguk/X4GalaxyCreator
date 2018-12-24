using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model.Json;
using System.Windows;

namespace GalaxyCreator.Dialogs.EconomyEditor
{
    class EconomyEditorDetailViewModel : DialogViewModelBase
    {
        private Product Product;
        private RelayCommand<object> _saveCommand;
        private RelayCommand<object> _cancelCommand;

        public EconomyEditorDetailViewModel(string message, Product product) : base(message)
        {
            this.Product = product;
            this._saveCommand = new RelayCommand<object>((parent) => OnSaveClicked(parent));
            this._cancelCommand = new RelayCommand<object>((parent) => OnCancelClicked(parent));
        }

        private void OnSaveClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }

        private void OnCancelClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
        }
    }
}
