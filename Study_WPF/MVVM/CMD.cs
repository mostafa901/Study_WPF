using System;
using System.Windows.Input;

namespace Shared_Lib.MVVM
{
    public class cus_CMD : BaseDataObject, ICommand
    {
        public enum ButtonStat
        {
            CanExecute,
            DontExecute
        }


        

        public event EventHandler CanExecuteChanged;

        public Action<object> Action { get; set; } = (x) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ButtonStat CommandState { get; private set; }

        public void SetButtonState(ButtonStat stat)
        {
            CommandState = stat;
        }

        public void Execute(object parameter)
        {
            if (CommandState == ButtonStat.CanExecute)
            {
                Action(parameter);
            }
        }
    }
}