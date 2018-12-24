using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaxyCreator.Dialogs.DialogFacade;
using GalaxyCreator.Model.EconomyEditor;
using GalaxyCreator.Model.Json;
using GalaxyCreator.Util;
using System.Windows;

namespace GalaxyCreator.ViewModel
{
    public class EconomyEditorViewModel : ViewModelBase
    {
        private IDialogFacade dialogFacade = null;
        private RelayCommand<object> _EconomyEditorDetailClickedCommand;
        private RelayCommand<object> _EconomyEditorRemoveClickedCommand;
        private RelayCommand<object> _EconomyEditorCopyClickedCommand;
        private RelayCommand<object> _EconomyEditorAddClickedCommand;

        public Galaxy Galaxy { get; set; }
        private ProductMemento ProductMemento;

        public EconomyEditorViewModel(Galaxy Galaxy)
        {
            this.Galaxy = Galaxy;
            this.dialogFacade = new DialogFacade();
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                Set(ref _selectedProduct, value);
            }
        }

        public RelayCommand<object> EconomyEditorClickedCommand
        {
            get
            {
                if (_EconomyEditorDetailClickedCommand == null)
                {
                    _EconomyEditorDetailClickedCommand = new RelayCommand<object>((param) => EconomyEditorClicked(param));
                }

                return _EconomyEditorDetailClickedCommand;
            }
        }

        public RelayCommand<object> EconomyEditorRemoveCommand
        {
            get
            {
                if (_EconomyEditorRemoveClickedCommand == null)
                {
                    _EconomyEditorRemoveClickedCommand = new RelayCommand<object>((param) => EconomyEditorRemoveClicked(param));
                }

                return _EconomyEditorRemoveClickedCommand;
            }
        }

        public RelayCommand<object> EconomyEditorCopyCommand
        {
            get
            {
                if (_EconomyEditorCopyClickedCommand == null)
                {
                    _EconomyEditorCopyClickedCommand = new RelayCommand<object>((param) => EconomyEditorCopyClicked(param));
                }

                return _EconomyEditorCopyClickedCommand;
            }
        }

        public RelayCommand<object> EconomyEditorAddCommand
        {
            get
            {
                if (_EconomyEditorAddClickedCommand == null)
                {
                    _EconomyEditorAddClickedCommand = new RelayCommand<object>((param) => EconomyEditorAddClicked(param));
                }

                return _EconomyEditorAddClickedCommand;
            }
        }

        private void EconomyEditorAddClicked(object param)
        {
            Product newProduct = new Product();
            newProduct.Id = "new Product";
            this.Galaxy.Products.Add(newProduct);
            this.SelectedProduct = newProduct;
        }

        private void EconomyEditorCopyClicked(object param)
        {
            if (this.SelectedProduct != null)
            {
                Product newProduct = new Product();
                CloneUtil.CopyProperties(this.SelectedProduct, newProduct);
                newProduct.Id = newProduct.Id + "_copy";
                this.Galaxy.Products.Add(newProduct);
                this.SelectedProduct = newProduct;
            }
        }

        private void EconomyEditorRemoveClicked(object param)
        {
            if (this.SelectedProduct != null)
            {
                this.Galaxy.Products.Remove(this.SelectedProduct);
            }
        }

        private void EconomyEditorClicked(object param)
        {
            this.ProductMemento = new ProductMemento(this.SelectedProduct);
            Dialogs.DialogService.DialogResult result = this.dialogFacade.ShowEconomyEditorDetail("Product Editor Detail", param as Window, this.SelectedProduct);
            if (result == Dialogs.DialogService.DialogResult.No)
            {
                CloneUtil.CopyProperties(ProductMemento.Product, this.SelectedProduct);
            }
        }

    }
}
