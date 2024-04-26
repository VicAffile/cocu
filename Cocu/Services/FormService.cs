using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Cocu.Services
{
    class FormService
    {
        public static readonly string StringEmailIsNotValid = "Adresse e-mail non valide";
        public static readonly string StringPasswordIsNull = "Mot de passe requis";
        public static readonly string StringPasswordIsNotValid = "Le mot de passe doit contenir au moins 8 caractères";
        public static readonly string StringIsNotSamePasswordAndConfirmation = "Les deux mots de passes sont différents";

        public static bool EmailIsValid(string email)
        {
            const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new(pattern);
            return regex.IsMatch(email);
        }

        public static bool PasswordIsNull(string password)
        {
            return string.IsNullOrEmpty(password);
        }

        public static bool PasswordIsValid(string password)
        {
            if (PasswordIsNull(password)) return false;
            return password.Length >= 8;
        }

        public static bool PasswordAndConfirmationAreSame(string password, string confirmation)
        {
            return password.Equals(confirmation);
        }

        public static void ShowErrorMessage(string message, TextBlock block)
        {
            block.Text = message;
            block.Visibility = Visibility.Visible;
        }
    }
}
