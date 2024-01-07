using Cooking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Interfaces
{
    public interface IUserRepository
    {
        // POST
        void AddUser(User user);

        // GET
        User GetUserByEmail(string email);

        // ANDERE
        bool UserExists(string email);
    }
}