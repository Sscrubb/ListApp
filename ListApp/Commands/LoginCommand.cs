using ListApp.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

namespace ListApp.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly ILoginInput _input;
        public LoginCommand(ILoginInput input)
        {
            _input = input;
        }

        public void InvokeExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _input.Login.Length > 0 && _input.Password.Length > 0;
        }

        public void Execute(object parameter)
        {
            var currentInputedLogin = _input.Login;
            if (DoLoginAttempt(out string error))
                _input.DoSuccessLogin();
            else
                _input.DoWrongLogin(error);
        }

        private bool DoLoginAttempt(out string error)
        {
            error = string.Empty;
            using (var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-JP1TLKH\SQLEXPRESS;Initial Catalog=ListApp;Integrated Security=True"))
            {
                try
                {
                    if (sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();

                    string query = "SELECT COUNT(1) FROM [User's data] WHERE LOGIN=@Login AND Password=@Password";
                    var sqlCmd = new SqlCommand(query, sqlConnection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Login", _input.Login);
                    sqlCmd.Parameters.AddWithValue("@Password", _input.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    return count == 1;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }
    }
}
