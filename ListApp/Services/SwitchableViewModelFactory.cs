using ListApp.ViewModels;
using System;

namespace ListApp.Services
{
    public class SwitchableViewModelFactory
    {
        private readonly ViewModelManager _parameter;
        public SwitchableViewModelFactory(ViewModelManager paramete)
        {
            _parameter = paramete;
        }

        public SwitchableViewModel Create(string name)
        {
            switch (name)
            {
                case "Login":
                    return new LoginViewModel(_parameter);
                case "SignUp":
                    return new SignUpViewModel(_parameter);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
