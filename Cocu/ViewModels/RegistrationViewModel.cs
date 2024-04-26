using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Cocu.Commands;
using Cocu.Services;

namespace Cocu.ViewModels
{
    class RegistrationViewModel
    {
        private string _email;
        private string _password;
        private string _confirmation;

        private AuthenticationService _authenticationService;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string Confirmation
        {
            get { return _confirmation; }
            set
            {
                if (_confirmation != value)
                {
                    _confirmation = value;
                    OnPropertyChanged(nameof(Confirmation));
                }
            }
        }

        public ICommand RegisterCommand { get; }

        public RegistrationViewModel(AuthenticationService authenticationService)
        {
            RegisterCommand = new RelayCommand(ClickRegister);
            _authenticationService = authenticationService;
        }

        private void ClickRegister(object parameter)
        {
            bool isValidEmail = FormService.EmailIsValid(_email);
            bool isNullPassword = FormService.PasswordIsNull(_password);
            bool isValidPassword = FormService.PasswordIsValid(_password);
            bool isSamePasswordAndConfirmation = FormService.PasswordAndConfirmationAreSame(_password, _confirmation);

            if (isValidEmail && !isNullPassword && isValidPassword && isSamePasswordAndConfirmation)
            {
                // Persistance des données du compte en base
                bool result = _authenticationService.Register(_email, _password);
                if (result)
                {
                    NavigateService.NavigateToWifiObjectListPage();
                }
                else
                {
                    MessageBox.Show("La création du compte n'a pas pu s'effectuer");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
