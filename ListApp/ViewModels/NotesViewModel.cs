using ListApp.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ListApp.ViewModels
{
    public class NotesViewModel : SwitchableViewModel
    {
        public NotesViewModel(FileIOService fileIOService, ViewModelManager viewModelManager) : base(viewModelManager)
        {
            _fileIOService = fileIOService;
            ToDoList = new ObservableCollection<ToDoItemViewModel>(_fileIOService.LoadData().Select(x => new ToDoItemViewModel(x)));
            ToDoList.CollectionChanged += ToDoListChanged;
        }

        private readonly FileIOService _fileIOService;
        public ObservableCollection<ToDoItemViewModel> ToDoList { get; private set; }

        private void ToDoListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    _fileIOService.SaveData(ToDoList.Select(x => x.Model).ToList());
                    break;
                default:
                    break;
            }
        }
    }
}
