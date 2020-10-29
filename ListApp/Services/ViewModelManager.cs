using ListApp.Models.Events;
using ListApp.ViewModels;
using System;
using System.Collections.Generic;

namespace ListApp.Services
{
    public class ViewModelManager
    {
        private readonly Dictionary<string, BaseViewModel> _cachedViews = new Dictionary<string, BaseViewModel>();
        public SwitchableViewModelFactory Factory { get; internal set; }
        public void SwitchTo(string viewModelName)
        {
            if (!_cachedViews.TryGetValue(viewModelName, out var cached))
            {
                cached = Factory.Create(viewModelName);
                _cachedViews.Add(viewModelName, cached);
            }
            SwitchedView?.Invoke(new SwitchViewEventArgs() { NewViewModel = cached });
        }

        public event Action<SwitchViewEventArgs> SwitchedView;
    }
}
