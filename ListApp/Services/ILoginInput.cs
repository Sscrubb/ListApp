namespace ListApp.Services
{
    public interface ILoginInput
    {
        string Login { get; }
        string Password { get; }
        void DoSuccessLogin();
        void DoWrongLogin(string error = "");
    }
}
