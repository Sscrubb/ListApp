using ListApp.Models.Events;
using ListApp.Services;
using System;
using System.Windows.Input;

namespace ListApp.Commands
{
    public class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewManager _viewManager;
        public SwitchViewCommand(ViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var name = parameter.ToString();
            var type = Type.GetType(name);
            
            OnExecuted?.Invoke(new SwitchViewEventArgs() { NewView = _viewManager.GetView(type) });
        }

        public event Action<SwitchViewEventArgs> OnExecuted;
    }
}
