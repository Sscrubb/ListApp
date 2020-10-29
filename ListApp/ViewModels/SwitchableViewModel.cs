using ListApp.Commands;
using System.Windows.Input;

namespace ListApp.ViewModels
{
    public abstract class SwitchableViewModel : BaseViewModel
    {
        public SwitchableViewModel(SwitchViewCommand switchViewCommand): base()
        {
            SwitchViewCommand = switchViewCommand;
        }

        public ICommand SwitchViewCommand { get; private set; }
    }

}
