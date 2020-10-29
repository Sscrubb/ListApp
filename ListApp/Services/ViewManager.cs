using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ListApp.Services
{
    public class ViewManager
    {
        private List<UserControl> _cachedViews = new List<UserControl>();

        public UserControl GetView(Type viewType)
        {
            var cached = _cachedViews.FirstOrDefault(x => x.GetType() == viewType);
            if (cached == null)
            {
                cached = (UserControl)Activator.CreateInstance(viewType);
                _cachedViews.Add(cached);
            }
            return cached;
        }
    }
}
