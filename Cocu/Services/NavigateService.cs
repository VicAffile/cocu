using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cocu.Services
{
    internal class NavigateService
    {
        private static Frame _frame;

        public static void Initialize(Frame frame)
        {
            _frame = frame;
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
    }
}
