using Cocu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cocu.Views
{
    public partial class ConnectionView : Page
    {
        public ConnectionView()
        {
            InitializeComponent();
        }

        private void TxtPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password;

            bool isNullPassword = FormService.PasswordIsNull(password);

            if (isNullPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNull, txtError);
            }
            else
            {
                txtBindPassword.Text = password;
            }
        }

        private void FormIsValid(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password;

            bool isNullPassword = FormService.PasswordIsNull(password);

            if (isNullPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNull, txtError);
            }
            else
            {
                txtError.Visibility = Visibility.Collapsed;
            }
        }
    }
}
