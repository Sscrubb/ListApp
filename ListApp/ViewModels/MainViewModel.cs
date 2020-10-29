using ListApp.Services;

namespace ListApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _viewManager = new ViewModelManager();
            var factory = new SwitchableViewModelFactory(_viewManager);
            _viewManager.Factory = factory;
            _viewManager.SwitchedView += (v) => CurrentViewModel = v.NewViewModel;
            _viewManager.SwitchTo("Login");
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
