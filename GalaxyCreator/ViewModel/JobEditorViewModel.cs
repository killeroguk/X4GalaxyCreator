using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogFacade;
using GalaxyCreator.Model.Json;

namespace GalaxyCreator.ViewModel
{
    class JobEditorViewModel : ViewModelBase
    {
        private IDialogFacade dialogFacade = null;
        private RelayCommand<object> _jobEditorDetailClickedCommand;

        public Galaxy Galaxy { get; set; }

        public JobEditorViewModel(Galaxy Galaxy)
        {
            this.Galaxy = Galaxy;
            this.dialogFacade = new DialogFacade();
        }

        public RelayCommand<object> JobEditorClickedCommand
        {
            get
            {
                if (_jobEditorDetailClickedCommand == null)
                {
                    _jobEditorDetailClickedCommand = new RelayCommand<object>((parent) => JobEditorClicked(parent));
                }

                return _jobEditorDetailClickedCommand;
            }
        }

        private void JobEditorClicked(object parent)
        {
            Dialogs.DialogService.DialogResult result = this.dialogFacade.ShowDialogYesNo("Question", parent as Window);           
        }
    }
}
