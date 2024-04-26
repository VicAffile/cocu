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

using Cocu.Services;

namespace Cocu.Views
{
    public partial class RegistrationView : Page
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void TxtEmailLostFocus(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;

            bool isValidEmail = FormService.EmailIsValid(email);

            // Détermine si un message d'erreur doit être affiché
            if (!isValidEmail)
            {
                FormService.ShowErrorMessage(FormService.StringEmailIsNotValid, txtError);
            }
            else
            {
                txtError.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password;

            bool isNullPassword = FormService.PasswordIsNull(password);
            bool isValidPassword = FormService.PasswordIsValid(password);

            // Détermine si un message d'erreur doit être affiché
            if (isNullPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNull, txtError);
            }
            else if (!isValidPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNotValid, txtError);
            }
            else
            {
                txtError.Visibility = Visibility.Collapsed;
                txtBindPassword.Text = password;
            }
        }

        private void TxtConfirmationLostFocus(object sender, RoutedEventArgs e)
        {
            string password = txtPassword.Password;
            string confirmation = txtConfirmation.Password;

            bool isSamePasswordAndConfirmation = FormService.PasswordAndConfirmationAreSame(password, confirmation);

            // Détermine si un message d'erreur doit être affiché
            if (!isSamePasswordAndConfirmation)
            {
                FormService.ShowErrorMessage(FormService.StringIsNotSamePasswordAndConfirmation, txtError);
            }
            else
            {
                txtError.Visibility = Visibility.Collapsed;
                txtBindConfirmation.Text = confirmation;
            }
        }

        private void FormIsValid(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            string confirmation = txtConfirmation.Password;

            bool isValidEmail = FormService.EmailIsValid(email);
            bool isNullPassword = FormService.PasswordIsNull(password);
            bool isValidPassword = FormService.PasswordIsValid(password);
            bool isSamePasswordAndConfirmation = FormService.PasswordAndConfirmationAreSame(password, confirmation);

            // Détermine si un message d'erreur doit être affiché
            if (!isValidEmail)
            {
                FormService.ShowErrorMessage(FormService.StringEmailIsNotValid, txtError);
            }
            else if (isNullPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNull, txtError);
            }
            else if (!isValidPassword)
            {
                FormService.ShowErrorMessage(FormService.StringPasswordIsNotValid, txtError);
            }
            else if (!isSamePasswordAndConfirmation)
            {
                FormService.ShowErrorMessage(FormService.StringIsNotSamePasswordAndConfirmation, txtError);
            }
            else
            {
                txtError.Visibility = Visibility.Collapsed;
            }
        }
    }
}
