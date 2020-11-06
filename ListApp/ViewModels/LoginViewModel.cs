using ListApp.Commands;
using ListApp.Services;
using System.Windows;

namespace ListApp.ViewModels
{
    public class LoginViewModel : SwitchableViewModel, ILoginInput
    {
        public LoginViewModel(ViewModelManager paramter) : base(paramter)
        {
            LoginCommand = new LoginCommand(this);
            _login = string.Empty;
            _password = string.Empty; 
            Login = "Buttfuckhero"; 
            Password = "555462ul";
        }

        private string _login;
        public string Login 
        { 
            get => _login;
            set {
                if (_login != value)
                {
                    _login = value;
                    this.GeneratePropertyChangedEvent(nameof(Login));
                    CheckIfLoginEnabled();
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    this.GeneratePropertyChangedEvent(nameof(Password));
                    CheckIfLoginEnabled();
                }
            }
        }

        private void CheckIfLoginEnabled()
        {
            if (Password.Length > 0 && Login.Length > 0)
                LoginCommand.InvokeExecuteChanged();
        }
        public LoginCommand LoginCommand { get; }

        public void DoSuccessLogin()
        {
            SwitchViewCommand.Execute("Notes");
        }

        public void DoWrongLogin(string error = "")
        {
            if (string.IsNullOrEmpty(error))
                MessageBox.Show("Неверный логин и / или пароль!");
            else
                MessageBox.Show( error, "Произошла ошибка!");
        }
    }
}
