using ListApp.ViewModels;
using System;

namespace ListApp.Services
{
    public class SwitchableViewModelFactory
    {
        private readonly ViewModelManager _parameter;
        private readonly FileIOService _ioParameter;
        public SwitchableViewModelFactory(ViewModelManager paramete)
        {
            _parameter = paramete;
            //var path = ConfigurationManager.AppSettings["LocalCachePath"];
            var path = $"{Environment.CurrentDirectory}\\ListAppModels.json";
            _ioParameter = new FileIOService(path);
        }

        public SwitchableViewModel Create(string name)
        {
            switch (name)
            {
                case "Login":
                    return new LoginViewModel(_parameter);
                case "SignUp":
                    return new SignUpViewModel(_parameter);
                case "Notes":
                    return new NotesViewModel(_ioParameter, _parameter);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
