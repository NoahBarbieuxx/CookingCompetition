using Cooking.BL.Exceptions;
using Cooking.BL.Interfaces;
using Cooking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Managers
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository repo)
        {
            _userRepository = repo;
        }

        public void AddUser(User user)
        {
            try
            {
                _userRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                throw new UserManagerException("AddUser", ex);
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _userRepository.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                throw new UserManagerException("GetUserByEmail", ex);
            }
        }

        public bool UserExists(string email)
        {
            try
            {
                return _userRepository.UserExists(email);
            }
            catch (Exception ex)
            {
                throw new UserManagerException("UserExists", ex);
            }
        }
    }
}