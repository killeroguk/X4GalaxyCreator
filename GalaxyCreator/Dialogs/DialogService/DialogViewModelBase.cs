using System.Windows;

namespace GalaxyCreator.Dialogs.DialogService
{
    public abstract class DialogViewModelBase
    {
        public DialogResult UserDialogResult
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }

        public DialogViewModelBase(string message)
        {
            this.Message = message;
        }

        public void CloseDialogWithResult(Window dialog, DialogResult result)
        {
            this.UserDialogResult = result;
            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}
