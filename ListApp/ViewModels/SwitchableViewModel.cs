using ListApp.Commands;
using ListApp.Services;
using System.Windows.Input;

namespace ListApp.ViewModels
{
    public abstract class SwitchableViewModel : BaseViewModel
    {
        public SwitchableViewModel(ViewModelManager viewModelManager): base()
        {
            SwitchViewCommand = new SwitchViewCommand(viewModelManager);
        }

        public ICommand SwitchViewCommand { get; private set; }
    }

}
