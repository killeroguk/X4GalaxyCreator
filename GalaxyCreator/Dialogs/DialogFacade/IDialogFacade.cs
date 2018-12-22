using GalaxyCreator.Dialogs.DialogService;
using GalaxyCreator.Model.Json;
using System.Windows;

namespace GalaxyCreator.Dialogs.DialogFacade
{
    public interface IDialogFacade
    {
        DialogResult ShowDialogYesNo(string message, Window owner);

        DialogResult ShowJobEditorDetail(string message, Window owner, Job job);
    }
}
