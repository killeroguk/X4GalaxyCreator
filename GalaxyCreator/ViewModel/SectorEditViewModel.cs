using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GalaxyCreator.ViewModel
{
    public class SectorEditViewModel: ViewModelBase
    {
        private Cluster _selectedMapCluster;

        private RelayCommand _isEnabledClickedCommand;

        private RelayCommand _addStationClickCommand;

        private RelayCommand _addBeltClickCommand;

        public Cluster SelectedMapCluster
        {
            get
            { 
                return _selectedMapCluster;
            }
            set
            {
                Set(ref _selectedMapCluster, value);
            }
        }

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

        public SectorEditViewModel(Cluster cluser)
        {
            SelectedMapCluster = cluser;
        }


        public void IsEnabledClicked()
        {
            if(_selectedMapCluster.IsEnabled == true)
            {
                _selectedMapCluster.Polygon.Fill = Brushes.Pink;
            }
            else
            {
                _selectedMapCluster.Polygon.Fill = Brushes.LightGray;
               
            }

        }

        public void AddStationClick()
        {
            _selectedMapCluster.Stations.Add(new Station());
        }

        public void AddBeltClick()
        {
            _selectedMapCluster.Belts.Add(new Belt());
        }
    }
}
