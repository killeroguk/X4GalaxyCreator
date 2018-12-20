using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model.Json;
using System.Windows;

namespace GalaxyCreator.Dialogs.JobEditor
{
    class JobEditorDetailViewModel : DialogViewModelBase
    {
        public Job Job { get; set; }

        private RelayCommand<object> _saveCommand = null;
        public RelayCommand<object> SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        private RelayCommand<object> _cancelCommand = null;
        public RelayCommand<object> CancelCommand
        {
            get { return _cancelCommand; }
            set { _cancelCommand = value; }
        }

        public JobEditorDetailViewModel(string message, Job job) : base(message)
        {
            this.Job = job;
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
