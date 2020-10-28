using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ListApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Login.Text.Length >= 30)
            {
                LogInWrong.Text = "Login must not be longer, than 30 simbols";
            }
        }

        private void SubPass_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Password.Password.Equals(SubPass.Password))
            {
                notEqualPass.Text = " ";
            }
            else
            {
                notEqualPass.Text = "Passwords are not equal.";
            }
        }

        private void SaveData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string name = Name.Text;
            string surname = Surname.Text;
            string birthDate = BirthDate.Text;
            string login = Login.Text;
            string password = Password.Password;
            string submitPassword = SubPass.Password;

            //to do: data base save
            //using (var con = new 

        }
    }
}
