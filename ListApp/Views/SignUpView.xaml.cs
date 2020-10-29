using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

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

            var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JP1TLKH\SQLEXPRESS;Initial Catalog=ListApp;Integrated Security=True");

            var sqlCommand = new SqlCommand("INSERT INTO [User's data] ([name], [surname], [birthDate], [login], [password], [submitPassword])" +
                "VALUES (@name, @surname, @birthDate, @login, @password, @submitPassword)");

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", Name.Text);
                sqlCommand.Parameters.AddWithValue("@surname", Surname.Text);
                sqlCommand.Parameters.AddWithValue("@birthDate", BirthDate.Text);
                sqlCommand.Parameters.AddWithValue("@login", Login.Text);
                sqlCommand.Parameters.AddWithValue("@password", Password.Password);
                sqlCommand.Parameters.AddWithValue("@submitPassword", SubPass.Password);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("A user with this login already exists! Choose another one.");
            }
        }
    }
}
