using ListApp.Models.Events;
using ListApp.Views;
using System;
using System.Windows.Input;

namespace ListApp.Commands
{
    public class SignUpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnExecuted?.Invoke(new SwitchViewEventArgs() { NewView = new SignUpView() });
        }

        public event Action<SwitchViewEventArgs> OnExecuted;
    }
}
