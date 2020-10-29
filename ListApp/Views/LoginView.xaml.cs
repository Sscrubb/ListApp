using System.Windows.Controls;

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

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Login.Text.Length > 30)
            {
                
            }
        }
    }
}
