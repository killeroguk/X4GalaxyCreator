using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model.EconomyEditor;
using GalaxyCreator.Model.Json;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GalaxyCreator.Dialogs.EconomyEditor
{
    class EconomyEditorDetailViewModel : DialogViewModelBase
    {
        public Product Product { get; set; }
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

        private RelayCommand<object> _productLocationFactionsUpdateCommand = null;
        public RelayCommand<object> ProductLocationFactionsUpdateCommand
        {
            get
            {
                if (_productLocationFactionsUpdateCommand == null)
                {
                    _productLocationFactionsUpdateCommand = new RelayCommand<object>((param) => UpdateFactionsOnJobLocation(param));
                }

                return _productLocationFactionsUpdateCommand;
            }
        }

        public String ProductLocationFactions
        {
            get
            {
                if (this.Product.LocationInfo.SpawnLocations != null)
                {
                    string Result = "{";
                    foreach (Faction Faction in this.Product.LocationInfo.SpawnLocations)
                    {
                        Result = Result + " " + Faction.ToString() + " ";
                    }
                    Result = Result + "}";
                    return Result;
                }
                return "";
            }
        }

        private void UpdateFactionsOnJobLocation(object param)
        {
            if (param != null)
            {
                Faction factionParam = (Faction)param;
                if (Product.LocationInfo.SpawnLocations.Contains(factionParam))
                {
                    Product.LocationInfo.SpawnLocations.Remove(factionParam);
                }
                else
                {
                    Product.LocationInfo.SpawnLocations.Add(factionParam);
                }
                RaisePropertyChanged("ProductLocationFactions");
            }
        }

        private IList<WareItem> _wares = new List<WareItem>();
        public IList<WareItem> Wares
        {
            get { return _wares; }
            set
            {
                Set(ref _wares, value);
            }
        }

        public EconomyEditorDetailViewModel(string message, Product product) : base(message)
        {
            this.Product = product;
            this._saveCommand = new RelayCommand<object>((parent) => OnSaveClicked(parent));
            this._cancelCommand = new RelayCommand<object>((parent) => OnCancelClicked(parent));
            foreach (String ware in Product.LocationInfo.Wares)
            {
                _wares.Add(new WareItem(ware));
            }
        }

        private void OnSaveClicked(object parameter)
        {
            this.Product.LocationInfo.Wares.Clear();
            foreach (WareItem item in _wares)
            {
                this.Product.LocationInfo.Wares.Add(item.Value);
            }
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }

        private void OnCancelClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
        }
    }
}
