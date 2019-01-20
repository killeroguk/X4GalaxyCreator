using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GalaxyCreator.Dialogs.JobEditor
{
    class JobEditorDetailViewModel : DialogViewModelBase
    {
        public Job Job { get; set; }

        public ShipSize? JobCategoryShipSize
        {
            get
            {
                if(Job.JobCategory.ShipSize == null)
                {
                    return ShipSize.NONE;
                }
                return Job.JobCategory.ShipSize;
            }
            set
            {
                if(value == ShipSize.NONE)
                {
                    Job.JobCategory.ShipSize = null;
                }
                else
                {
                    Job.JobCategory.ShipSize = value;
                }                
            }
        }

        public ShipSize? ShipShipSize
        {
            get
            {
                if (Job.Ship.Size == null)
                {
                    return ShipSize.NONE;
                }
                return Job.Ship.Size;
            }
            set
            {
                if (value == ShipSize.NONE)
                {
                    Job.Ship.Size = null;
                }
                else
                {
                    Job.Ship.Size = value;
                }
            }
        }

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

        private JobOrder _selectedOrder;
        public JobOrder SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                Set(ref _selectedOrder, value);
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

        private IList<StringItem> _subordinateItems = new List<StringItem>();
        public IList<StringItem> SubordinateItems
        {
            get { return _subordinateItems; }
            set
            {
                Set(ref _subordinateItems, value);
            }
        }

        private IList<StringItem> _jobCategoryTags = new List<StringItem>();
        public IList<StringItem> JobCategoryTags
        {
            get { return _jobCategoryTags; }
            set
            {
                Set(ref _jobCategoryTags, value);
            }
        }

        private IList<StringItem> _shipTags = new List<StringItem>();
        public IList<StringItem> ShipTags
        {
            get { return _shipTags; }
            set
            {
                Set(ref _shipTags, value);
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

        public JobEditorDetailViewModel(string message, Job job) : base(message)
        {
            this.Job = job;
            this._saveCommand = new RelayCommand<object>((parent) => OnSaveClicked(parent));
            this._cancelCommand = new RelayCommand<object>((parent) => OnCancelClicked(parent));
            foreach (String subordinate in Job.Subordinates)
            {
                _subordinateItems.Add(new StringItem(subordinate));
            }

            foreach (String JobCategoryTag in Job.JobCategory.Tags)
            {
                _jobCategoryTags.Add(new StringItem(JobCategoryTag));
            }

            foreach (String ShipTag in Job.Ship.Tags)
            {
                _shipTags.Add(new StringItem(ShipTag));
            }

        }

        private void OnSaveClicked(object parameter)
        {
            this.Job.Subordinates.Clear();
            foreach (StringItem item in _subordinateItems)
            {
                this.Job.Subordinates.Add(item.Value);
            }

            this.Job.JobCategory.Tags.Clear();
            foreach (StringItem item in _jobCategoryTags)
            {
                this.Job.JobCategory.Tags.Add(item.Value);
            }

            this.Job.Ship.Tags.Clear();
            foreach (StringItem item in _shipTags)
            {
                this.Job.Ship.Tags.Add(item.Value);
            }

            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }

        private void OnCancelClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
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
    }
}
