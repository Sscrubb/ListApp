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
                if (viewModel is LoginViewModel)
                    return element.FindResource("LoginView") as DataTemplate;
                else if (viewModel is SignUpViewModel)
                    return element.FindResource("SignUpView") as DataTemplate;
            }
            return null;
        }
    }
}
