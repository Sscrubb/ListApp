using System.Windows.Controls;
using System.Windows.Data;

namespace ListApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be = Password.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
        private void LoginChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be = Login.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
    }
}
