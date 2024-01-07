using Cooking.BL.Interfaces;
using Cooking.BL.Models;
using Cooking.EF.Exceptions;
using Cooking.EF.Mappers;
using Cooking.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.EF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly CookingContext _ctx;

        public UserRepositoryEF(string connectionString)
        {
            _ctx = new CookingContext(connectionString);
        }

        public void AddUser(User user)
        {
            try
            {
                UserEF userEF = MapUser.MapToDB(user);
                _ctx.Users.Add(userEF);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new UserRepositoryException("AddUser", ex);
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return MapUser.MapToDomain(_ctx.Users
                    .Include(x => x.Recipes)
                    .ThenInclude(x => x.Likes)
                    .Include(x => x.Recipes)
                    .ThenInclude(x => x.Images)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Email == email));

            }
            catch (Exception ex)
            {
                throw new UserRepositoryException("GetUserById", ex);
            }
        }

        public bool UserExists(string email)
        {
            try
            {
                return _ctx.Users.Any(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw new UserRepositoryException("UserExists", ex);
            }
        }

        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }
    }
}