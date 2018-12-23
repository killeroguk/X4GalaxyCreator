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

        private RelayCommand<object> _jobLocationsFactionUpdateCommand = null;
        public RelayCommand<object> JobLocationFactionsUpdateCommand
        {
            get
            {
                if (_jobLocationsFactionUpdateCommand == null)
                {
                    _jobLocationsFactionUpdateCommand = new RelayCommand<object>((param) => UpdateLocationsOnJobLocation(param));
                }

                return _jobLocationsFactionUpdateCommand;
            }
        }

        private RelayCommand<object> _shipFactionsTagUpdateCommand = null;
        public RelayCommand<object> ShipFactionsUpdateCommand
        {
            get
            {
                if (_shipFactionsTagUpdateCommand == null)
                {
                    _shipFactionsTagUpdateCommand = new RelayCommand<object>((param) => UpdateFactionsOnShip(param));
                }

                return _shipFactionsTagUpdateCommand;
            }
        }

        private RelayCommand<object> _shipTagsUpdateCommand = null;
        public RelayCommand<object> ShipTagsUpdateCommand
        {
            get
            {
                if (_shipTagsUpdateCommand == null)
                {
                    _shipTagsUpdateCommand = new RelayCommand<object>((param) => UpdateTagsOnShip(param));
                }

                return _shipTagsUpdateCommand;
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
                if(this.Job.JobCategory.Tags != null)
                {
                    string Result = "{";
                    foreach (Tag Tag in this.Job.JobCategory.Tags)
                    {
                        Result = Result + " " + Tag.ToString() + " ";
                    }
                    Result = Result + "}";
                    return Result;
                }
                return "";
            }
        }

        public String ShipTags
        {
            get
            {
                if(this.Job.Ship.Tags != null)
                {
                    string Result = "{";
                    foreach (Tag Tag in this.Job.Ship.Tags)
                    {
                        Result = Result + " " + Tag.ToString() + " ";
                    }
                    Result = Result + "}";
                    return Result;
                }
                return "";
            }
        }

        public String JobLocationFactions
        {
            get
            {
                if(this.Job.JobLocation.Factions != null)
                {
                    string Result = "{";
                    foreach (Faction Faction in this.Job.JobLocation.Factions)
                    {
                        Result = Result + " " + Faction.ToString() + " ";
                    }
                    Result = Result + "}";
                    return Result;
                }
                return "";
            }
        }

        public String ShipFactions
        {
            get
            {
                if(this.Job.Ship.Factions != null)
                {
                    string Result = "{";
                    foreach (Faction Faction in this.Job.Ship.Factions)
                    {
                        Result = Result + " " + Faction.ToString() + " ";
                    }
                    Result = Result + "}";
                    return Result;
                }
                return "";
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

        private void UpdateLocationsOnJobLocation(object param)
        {
            if (param != null)
            {
                Faction factionParam = (Faction)param;
                if (Job.JobLocation.Factions.Contains(factionParam))
                {
                    Job.JobLocation.Factions.Remove(factionParam);
                }
                else
                {
                    Job.JobLocation.Factions.Add(factionParam);
                }
                RaisePropertyChanged("JobLocationFactions");
            }
        }

        private void UpdateFactionsOnShip(object param)
        {
            if (param != null)
            {
                Faction factionParam = (Faction)param;
                if (Job.Ship.Factions.Contains(factionParam))
                {
                    Job.Ship.Factions.Remove(factionParam);
                }
                else
                {
                    Job.Ship.Factions.Add(factionParam);
                }
                RaisePropertyChanged("ShipFactions");
            }
        }

        private void UpdateTagsOnShip(object param)
        {
            if (param != null)
            {
                Tag tagParam = (Tag)param;
                if (Job.Ship.Tags.Contains(tagParam))
                {
                    Job.Ship.Tags.Remove(tagParam);
                }
                else
                {
                    Job.Ship.Tags.Add(tagParam);
                }
                RaisePropertyChanged("ShipTags");
            }
        }

    }
}
