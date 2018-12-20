using GalaxyCreator.Dialogs.DialogService;
using System.Windows;

/**
 * Information found on: https://www.c-sharpcorner.com/article/dialogs-in-wpf-mvvm/
**/
namespace GalaxyCreator.Dialogs.DialogFacade
{
    public class DialogFacade : IDialogFacade
    {
        public DialogFacade()
        {

        }

        public DialogResult ShowDialogYesNo(string message, Window owner)
        {
            DialogViewModelBase vm = new DialogYesNo.DialogYesNoViewModel(message);
            return this.ShowDialog(vm, owner);
        }

        private DialogResult ShowDialog(DialogViewModelBase vm, Window owner)
        {
            DialogWindow win = new DialogWindow();
            if (owner != null)
                win.Owner = owner;
            win.DataContext = vm;
            win.ShowDialog();
            DialogResult result =
                (win.DataContext as DialogViewModelBase).UserDialogResult;
            return result;
        }
    }
}
