using GalaxyCreator.Dialogs.DialogService;
using System.Windows;

namespace GalaxyCreator.Dialogs.DialogFacade
{
    public interface IDialogFacade
    {
        DialogResult ShowDialogYesNo(string message, Window owner);
    }
}
