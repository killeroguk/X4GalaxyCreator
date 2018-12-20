using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using System.Windows;
using System.Windows.Input;

namespace GalaxyCreator.Dialogs.DialogYesNo
{
    class DialogYesNoViewModel : DialogViewModelBase
    {
        private RelayCommand<object> yesCommand = null;
        public RelayCommand<object> YesCommand
        {
            get { return yesCommand; }
            set { yesCommand = value; }
        }

        private ICommand noCommand = null;
        public ICommand NoCommand
        {
            get { return noCommand; }
            set { noCommand = value; }
        }

        public DialogYesNoViewModel(string message) : base(message)
        {
            this.yesCommand = new RelayCommand<object>((parent) => OnYesClicked(parent));
            this.noCommand = new RelayCommand<object>((parent) => OnNoClicked(parent));
        }

        private void OnYesClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }

        private void OnNoClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
        }
    }
}
