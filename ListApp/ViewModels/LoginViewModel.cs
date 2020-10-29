using ListApp.Commands;

namespace ListApp.ViewModels
{
    public class LoginViewModel : SwitchableViewModel
    {
        public LoginViewModel(SwitchViewCommand switchViewCommand) : base(switchViewCommand)
        {
        }
    }
}
