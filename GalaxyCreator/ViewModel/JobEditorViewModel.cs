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
        private RelayCommand<object> _jobEditorRemoveClickedCommand;
        private RelayCommand<object> _jobEditorCopyClickedCommand;
        private RelayCommand<object> _jobEditorAddClickedCommand;

        public Galaxy Galaxy { get; set; }
        private JobMemento jobMemento;

        public JobEditorViewModel(Galaxy Galaxy)
        {
            this.Galaxy = Galaxy;
            this.dialogFacade = new DialogFacade();
        }

        private Job _selectedJob;
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                Set(ref _selectedJob, value);
            }
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

        public RelayCommand<object> JobEditorRemoveCommand
        {
            get
            {
                if (_jobEditorRemoveClickedCommand == null)
                {
                    _jobEditorRemoveClickedCommand = new RelayCommand<object>((param) => JobEditorRemoveClicked(param));
                }

                return _jobEditorRemoveClickedCommand;
            }
        }

        public RelayCommand<object> JobEditorCopyCommand
        {
            get
            {
                if (_jobEditorCopyClickedCommand == null)
                {
                    _jobEditorCopyClickedCommand = new RelayCommand<object>((param) => JobEditorCopyClicked(param));
                }

                return _jobEditorCopyClickedCommand;
            }
        }

        public RelayCommand<object> JobEditorAddCommand
        {
            get
            {
                if (_jobEditorAddClickedCommand == null)
                {
                    _jobEditorAddClickedCommand = new RelayCommand<object>((param) => JobEditorAddClicked(param));
                }

                return _jobEditorAddClickedCommand;
            }
        }

        private void JobEditorAddClicked(object param)
        {
            Job newJob = new Job();
            newJob.Id = "new job";
            this.Galaxy.Jobs.Add(newJob);
            this.SelectedJob = newJob;
        }

        private void JobEditorCopyClicked(object param)
        {
            if (this.SelectedJob != null)
            {
                Job newJob = new Job();
                CloneUtil.CopyProperties(this.SelectedJob, newJob);
                newJob.Id = newJob.Id + "_copy";
                this.Galaxy.Jobs.Add(newJob);
                this.SelectedJob = newJob;
            }
        }

        private void JobEditorRemoveClicked(object param)
        {
            if(this.SelectedJob != null)
            {
                this.Galaxy.Jobs.Remove(this.SelectedJob);
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
