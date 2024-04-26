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
    class ConnectionViewModel
    {
        private string _password;

        private AuthenticationService _authenticationService;

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

        public ICommand AuthenticateCommand { get; }

        public ConnectionViewModel(AuthenticationService authenticationService)
        {
            AuthenticateCommand = new RelayCommand(ClickAuthenticate);
            _authenticationService = authenticationService;
        }
        private void ClickAuthenticate(object parameter)
        {
            bool isAuthenticate = _authenticationService.Authenticate(_password);
            if (isAuthenticate)
            {
                NavigateService.NavigateToWifiObjectListPage();
            }
            else
            {
                MessageBox.Show("Le mot de passe n'est pas bon");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
