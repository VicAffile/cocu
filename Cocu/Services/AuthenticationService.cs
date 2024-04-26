using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Cocu.Models;
using Cocu.Repositories;

namespace Cocu.Services
{
    class AuthenticationService(UserRepository utilisateurRepository)
    {
        private readonly UserRepository _userRepository = utilisateurRepository;

        public bool Register(string email, string password)
        {
            if (AccountExist()) return false; // L'utilisateur existe déjà

            // Hacher le mot de passe
            string hashPassword = HashPassword(password);

            UserModel user = new(Guid.NewGuid(), email, hashPassword);

            // Ajouter l'utilisateur à la base de données
            _userRepository.AddUser(user);

            return true; // Inscription réussie
        }

        public bool Authenticate(string password)
        {
            // Vérification de l'existence d'un profil (et uniquement un)
            if (!AccountExist()) return false;

            // Récupérer l'utilisateur
            UserModel user = _userRepository.getUser();

            // Vérifier si l'utilisateur existe
            if (user == null) return false; // L'utilisateur n'existe pas

            // Vérifier le mot de passe
            return VerifyPassword(password, user.Password);
        }

        public bool AccountExist()
        {
            // On récupère le nombre de profil
            int nbrUser = _userRepository.GetAllUsers().Count;
            // S'il y en a plus d'un c'est anormal
            if (nbrUser > 1) throw new InvalidOperationException("Plusiers profils existe"); // Au moins deux profils existent en base
            return nbrUser.Equals(1);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string hashPassword)
        {
            return HashPassword(password).Equals(hashPassword);
        }
    }
}
