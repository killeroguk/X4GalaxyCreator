using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Model;
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
        private Sector _selectedSector;

        private RelayCommand _isEnabledClickedCommand;

        private RelayCommand _addStationClickCommand;

        private RelayCommand _addBeltClickCommand;

        public Sector SelectedSector
        {
            get
            { 
                return _selectedSector;
            }
            set
            {
                Set(ref _selectedSector, value);
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

        public SectorEditViewModel(Sector sector)
        {
            SelectedSector = sector;
        }


        public void IsEnabledClicked()
        {
            if(_selectedSector.IsEnabled == true)
            {
                _selectedSector.Hex.canvasElement.FillBrush = Brushes.Pink;
            }
            else
            {
                _selectedSector.Hex.canvasElement.FillBrush = Brushes.LightGray;
               
            }

            MainData.UpdateCanvas();
        }

        public void AddStationClick()
        {
            _selectedSector.Stations.Add(new Station());
        }

        public void AddBeltClick()
        {
            _selectedSector.Belts.Add(new Belt());
        }
    }
}
