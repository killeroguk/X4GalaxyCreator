using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogFacade;
using GalaxyCreator.Model.JobEditor;
using GalaxyCreator.Model.Json;
using GalaxyCreator.Util;

namespace GalaxyCreator.ViewModel
{
    class JobEditorViewModel : ViewModelBase
    {
        private IDialogFacade dialogFacade = null;
        private RelayCommand<object> _jobEditorDetailClickedCommand;

        public Galaxy Galaxy { get; set; }
        public Job SelectedJob { get; set; }
        private JobMemento jobMemento;

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
                    _jobEditorDetailClickedCommand = new RelayCommand<object>((param) => JobEditorClicked(param));
                }

                return _jobEditorDetailClickedCommand;
            }
        }

        private void JobEditorClicked(object param)
        {
            this.jobMemento = new JobMemento(this.SelectedJob);
            Dialogs.DialogService.DialogResult result = this.dialogFacade.ShowJobEditorDetail("Job Editor Detail", param as Window, this.SelectedJob);           
            if(result == Dialogs.DialogService.DialogResult.No)
            {
                CloneUtil.CopyProperties(jobMemento.Job, this.SelectedJob);
            }
        }
    }
}
