using ListApp.Models.Events;
using ListApp.Services;
using System;
using System.Windows.Input;

namespace ListApp.Commands
{
    public class SwitchViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModelManager _viewManager;
        public SwitchViewCommand(ViewModelManager viewManager)
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
            
            OnExecuted?.Invoke(new SwitchViewEventArgs() { NewViewModel = _viewManager.GetViewModel(type) });
        }

        public event Action<SwitchViewEventArgs> OnExecuted;
    }
}
