using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model.Json;
using System;
using System.Collections.ObjectModel;
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

        private RelayCommand<object> _jobCategoryTagUpdateCommand = null;
        public RelayCommand<object> JobCategoryTagUpdateCommand
        {
            get
            {
                if (_jobCategoryTagUpdateCommand == null)
                {
                    _jobCategoryTagUpdateCommand = new RelayCommand<object>((param) => UpdateTagOnJobCategory(param));
                }

                return _jobCategoryTagUpdateCommand;
            }
        }

        private JobOrder _selectedOrder;
        public JobOrder SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                Set(ref _selectedOrder, value);
            }
        }

        public String JobCategoryTags
        {
            get
            {
                string Result = "{";
                foreach(Tag Tag in this.Job.JobCategory.Tags)
                {
                    Result = Result + " " + Tag.ToString() + " ";
                }
                Result = Result + "}";
                return Result;
            }
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

        private void UpdateTagOnJobCategory(object param)
        {
            if(param != null)
            {
                Tag tagParam = (Tag)param;
                Console.WriteLine("tag clicked");
                if (Job.JobCategory.Tags.Contains(tagParam))
                {
                    Job.JobCategory.Tags.Remove(tagParam);
                }
                else
                {
                    Job.JobCategory.Tags.Add(tagParam);
                }
                RaisePropertyChanged("JobCategoryTags");
            }
        }
    }
}
