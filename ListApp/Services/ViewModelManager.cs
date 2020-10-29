using ListApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListApp.Services
{
    public class ViewModelManager
    {
        private List<BaseViewModel> _cachedViews = new List<BaseViewModel>();

        public BaseViewModel GetViewModel(Type viewModelType)
        {
            var cached = _cachedViews.FirstOrDefault(x => x.GetType() == viewModelType);
            if (cached == null)
            {
                cached = (BaseViewModel)Activator.CreateInstance(viewModelType);
                _cachedViews.Add(cached);
            }
            return cached;
        }

        public void RegisterViewModel(BaseViewModel viewModel)
        {
            var cached = _cachedViews.FirstOrDefault(x => x.GetType() == viewModel.GetType());
            if (cached == null)
                _cachedViews.Add(viewModel);
        }
    }
}
