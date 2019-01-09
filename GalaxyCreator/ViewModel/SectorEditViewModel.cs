using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using GalaxyCreator.Util;
using GalaxyCreator.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GalaxyCreator.ViewModel
{

    public class SectorEditViewModel: ViewModelBase, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly ClusterValidator _clusterValidator;


        public Cluster Cluster { get; set; }

        public String Name { get { return Cluster.Name; } set { Cluster.Name = value; RaisePropertyChanged("Name"); } }
        public String Description { get { return Cluster.Description; } set { Cluster.Description = value; RaisePropertyChanged("Description"); } }
        public String Music { get { return Cluster.Music; } set { Cluster.Music = value; RaisePropertyChanged("Music"); } }
        public String Sunlight { get { return Cluster.Sunlight; } set { Cluster.Sunlight = value; RaisePropertyChanged("Sunlight"); } }
        public String Economy { get { return Cluster.Economy; } set { Cluster.Economy = value; RaisePropertyChanged("Economy"); } }
        public String Security { get { return Cluster.Security; } set { Cluster.Security = value; RaisePropertyChanged("Security"); } }
        public String Backdrop { get { return Cluster.Backdrop; } set { Cluster.Backdrop = value; RaisePropertyChanged("Backdrop"); } }
        public Faction? FactionHq { get { return Cluster.FactionHq; } set { Cluster.FactionHq = value; RaisePropertyChanged("FactionHq"); } }
        public bool GameStart { get { return Cluster.GameStart; } set { Cluster.GameStart = value; RaisePropertyChanged("GameStart"); } }
        public Int32? Credits { get { return Cluster.FactionStart.Credits; } set { Cluster.FactionStart.Credits = value; RaisePropertyChanged("Credits"); } }


        public ObservableCollection<string> _targetClusterIds = new ObservableCollection<string>();

        private RelayCommand _isEnabledClickedCommand;

        private RelayCommand _addStationClickCommand;

        private RelayCommand _addBeltClickCommand;

        private RelayCommand _addSpaceObjectClickCommand;

        private RelayCommand _addConnectionClickCommand;

        private RelayCommand<object> _deleteStationClickCommand;

        private RelayCommand<object> _deleteBeltClickCommand;

        private RelayCommand<object> _deleteSpaceObjectCommand;

        //public Cluster Cluster
        //{
        //    get
        //    { 
        //        return _Cluster;
        //    }
        //    set
        //    {
        //        Set(ref _Cluster, value);
        //    }
        //}

        public RelayCommand IsEnabledClickedCommand
        {
            get
            {
                if (_isEnabledClickedCommand == null)
                {
                    _isEnabledClickedCommand = new RelayCommand(() => IsEnabledClicked());
                }

                return _isEnabledClickedCommand;
            }
        }

        public RelayCommand AddStationClickCommand
        {
            get
            {
                if (_addStationClickCommand == null)
                {
                    _addStationClickCommand = new RelayCommand(() => AddStationClick());
                }

                return _addStationClickCommand;
            }
        }

        public RelayCommand AddBeltClickCommand
        {
            get
            {
                if (_addBeltClickCommand == null)
                {
                    _addBeltClickCommand = new RelayCommand(() => AddBeltClick());
                }

                return _addBeltClickCommand;
            }
        }

        public RelayCommand AddSpaceObjectClickCommand
        {
            get
            {
                if (_addSpaceObjectClickCommand == null)
                {
                    _addSpaceObjectClickCommand = new RelayCommand(() => AddSpaceObjectClick());
                }

                return _addSpaceObjectClickCommand;
            }
        }

        public RelayCommand AddConnectionClickCommand
        {
            get
            {
                if (_addConnectionClickCommand == null)
                {
                    _addConnectionClickCommand = new RelayCommand(() => AddConnectionClick());
                }

                return _addConnectionClickCommand;
            }
        }

        public RelayCommand<object> DeleteStationClickCommand
        {
            get
            {
                if (_deleteStationClickCommand == null)
                {
                    _deleteStationClickCommand = new RelayCommand<object>((parm) => DeleteStationClick(parm));
                }

                return _deleteStationClickCommand;
            }
        }

        public RelayCommand<object> DeleteBeltClickCommand
        {
            get
            {
                if (_deleteBeltClickCommand == null)
                {
                    _deleteBeltClickCommand = new RelayCommand<object>((parm) => DeleteBeltClick(parm));
                }

                return _deleteBeltClickCommand;
            }
        }

        public RelayCommand<object> DeleteSpaceObjectClickCommand
        {
            get
            {
                if (_deleteSpaceObjectCommand == null)
                {
                    _deleteSpaceObjectCommand = new RelayCommand<object>((parm) => DeleteSpaceObjectClick(parm));
                }

                return _deleteSpaceObjectCommand;
            }
        }


        public ObservableCollection<string> TargetClusterIds
        {
            get
            {
                return _targetClusterIds;
            }
            set
            {
                Set(ref _targetClusterIds, value);
            }
        }

        public SectorEditViewModel(Cluster cluster)
        {
            Cluster = cluster;
            _clusterValidator = new ClusterValidator();

            MainData.SelectedMapCluster = cluster;

            var targetClusters = MainData.GetGalaxyMap().Clusters.Where(c => c != Cluster && c.IsEnabled == true).Select(c => c.Id);

            foreach (var c in targetClusters)
            {
                TargetClusterIds.Add(c);
            }
            
        }

        public void IsEnabledClicked()
        {
            if(Cluster.IsEnabled == true)
            {
                ClusterHelperFunctions.ChooseClusterFillColour(Cluster);
            }
            else
            {
                Cluster.Polygon.Fill = Brushes.LightGray;
               
            }

        }

        public void AddStationClick()
        {
            Cluster.Stations.Add(new Station());
            ClusterHelperFunctions.ChooseClusterFillColour(Cluster);
        }

        public void AddBeltClick()
        {
            Cluster.Belts.Add(new Belt());
        }

        public void AddSpaceObjectClick()
        {
            Cluster.SpaceObjects.Add(new SpaceObject());
        }

        public void AddConnectionClick()
        {
            Cluster.Connections.Add(new Connection());
        }

        public void DeleteStationClick(object ob)
        {
            Cluster.Stations.Remove((Station)ob);

            ClusterHelperFunctions.ChooseClusterFillColour(Cluster);
        }

        public void DeleteBeltClick(object ob)
        {
            Cluster.Belts.Remove((Belt)ob);
        }

        public void DeleteSpaceObjectClick(object ob)
        {
            Cluster.SpaceObjects.Remove((SpaceObject)ob);
        }

        public string this[string columnName]
        {
            get
            {
                if (Cluster != null)
                {
                    var firstOrDefault = _clusterValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                    if (firstOrDefault != null)
                        return _clusterValidator != null ? firstOrDefault.ErrorMessage : "";
                }
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_clusterValidator != null)
                {
                    var results = _clusterValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        private bool HasErrors()
        {
            return Error != string.Empty;
        }

    }
}
