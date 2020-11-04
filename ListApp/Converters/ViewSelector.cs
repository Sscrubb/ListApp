using ListApp.Services;
using ListApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ListApp.Converters
{
    public class ViewSelector : DataTemplateSelector
    {
        public sealed override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            var viewModel = item as BaseViewModel;
            if (element != null && viewModel != null)
            {
                var type = viewModel.GetType();
                string resourceKey = ViewHelper.GetViewKey(type);
                var found = element.FindResource(resourceKey) as DataTemplate;
                return found;
            }
            return null;
        }
    }
}
