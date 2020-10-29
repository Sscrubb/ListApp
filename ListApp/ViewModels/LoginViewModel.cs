using ListApp.Commands;
using ListApp.Services;

namespace ListApp.ViewModels
{
    public class LoginViewModel : SwitchableViewModel
    {
        public LoginViewModel(ViewModelManager paramter) : base(paramter)
        {
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
                }
            }
        }
    }
}
