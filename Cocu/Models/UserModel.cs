using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocu.Models
{
    class UserModel(Guid id, string email, string password)
    {
        public Guid Id { get; set; } = id;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
