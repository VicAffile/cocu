using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cocu.Data;
using Cocu.Models;

namespace Cocu.Repositories
{
    class UserRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public UserModel GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public UserModel getUser()
        {
            return _context.Users.FirstOrDefault();
        }

        public List<UserModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
