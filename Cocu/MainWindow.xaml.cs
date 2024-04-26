using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Cocu.Data;
using Cocu.Repositories;
using Cocu.Services;

namespace Cocu
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            NavigateService.Initialize(MainContent);
<<<<<<< Updated upstream
=======

            AppDbContext appDbContext = new();
            UserRepository userRepository = new(appDbContext);
            AuthenticationService authenticationService = new(userRepository);

            bool isAccountExist = authenticationService.AccountExist();
            if (isAccountExist)
            {
                NavigateService.NavigateToConnectionPage();
            }
            else
            {
                NavigateService.NavigateToRegisterPage();
            }
>>>>>>> Stashed changes
        }
    }
}