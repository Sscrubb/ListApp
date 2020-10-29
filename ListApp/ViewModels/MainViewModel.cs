using ListApp.Commands;
using ListApp.Services;
using ListApp.Views;
using System.ComponentModel;
using System.Windows.Controls;

namespace ListApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            CurrentView = new LoginView();
            var viewManager = new ViewManager();
            SignUpCommand = new SwitchViewCommand(viewManager);
            SignUpCommand.OnExecuted += (v) => CurrentView = v.NewView;
        }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set {
                if (_currentView != value)
                {
                    _currentView = value;
                    GeneratePropertyChangedEvent(nameof(CurrentView));
                } 
            }
        }

        public SwitchViewCommand SignUpCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GeneratePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
