using ListApp.Services;
using System;
using System.Windows.Input;

namespace ListApp.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly ILoginInput _input;
        public LoginCommand(ILoginInput input)
        {
            _input = input;
        }

        public void InvokeExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _input.Login.Length > 0 && _input.Password.Length > 0;
        }

        public void Execute(object parameter)
        {
            var currentInputedLogin = _input.Login;
            // как-то проверяем.
            if (_input.Password == "1")
                _input.DoSuccessLogin();
            else
                _input.DoWrongLogin();
        }
    }
}
