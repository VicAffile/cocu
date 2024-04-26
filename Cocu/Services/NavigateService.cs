using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using Cocu.Data;
using Cocu.Repositories;
using Cocu.ViewModels;
using Cocu.Views;

namespace Cocu.Services
{
    class NavigateService
    {
        private static Frame _frame;
        private static AppDbContext _appDbContext;

        public static void Initialize(Frame frame)
        {
            _frame = frame;
            _appDbContext = new AppDbContext();
        }

        public static void NavigateTo(Page page)
        {
            if (_frame != null)
            {
                _frame.Navigate(page);
            }
            else
            {
                throw new InvalidOperationException("Le Frame n'a pas été initialisé.");
            }
        }

        public static void NavigateToRegisterPage()
        {
            UserRepository userRepository = new(_appDbContext);
            AuthenticationService authenticationService = new(userRepository);
            RegistrationViewModel registrationViewModel = new(authenticationService);

            RegistrationView registrationView = new()
            {
                DataContext = registrationViewModel
            };

            NavigateTo(registrationView);
        }

        public static void NavigateToConnectionPage()
        {
            UserRepository userRepository = new(_appDbContext);
            AuthenticationService authenticationService = new(userRepository);
            ConnectionViewModel connectionViewModel = new(authenticationService);

            ConnectionView connectionView = new()
            {
                DataContext = connectionViewModel
            };

            NavigateTo(connectionView);
        }

        public static void NavigateToWifiObjectListPage()
        {
            WifiScannerService wifiScannerService = new();
            WifiObjectListViewModel wifiObjectListViewModel = new(wifiScannerService);

            WifiObjectListView wifiObjectListView = new WifiObjectListView()
            {
                DataContext = wifiObjectListViewModel
            };

            NavigateTo(wifiObjectListView);
        }
    }
}
