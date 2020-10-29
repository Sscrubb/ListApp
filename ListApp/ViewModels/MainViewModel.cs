using ListApp.Commands;
using ListApp.Services;
using ListApp.Views;
using System.ComponentModel;
using System.Windows.Controls;

namespace ListApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _viewManager = new ViewModelManager();
            var signUpCommand = new SwitchViewCommand(_viewManager);
            CurrentViewModel = new LoginViewModel(signUpCommand);
            signUpCommand.OnExecuted += (v) => CurrentViewModel = v.NewViewModel;
            _viewManager.RegisterViewModel(CurrentViewModel);
        }

        private BaseViewModel _currentViewModel;
        private ViewModelManager _viewManager;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    GeneratePropertyChangedEvent(nameof(CurrentViewModel));
                } 
            }
        }

    }
}
