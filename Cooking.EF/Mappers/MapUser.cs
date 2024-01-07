using Cooking.BL.Models;
using Cooking.EF.Exceptions;
using Cooking.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.EF.Mappers
{
    public class MapUser
    {
        public static UserEF MapToDB(User user)
        {
            try
            {
                return new UserEF(user.Email, null);
            }
            catch (Exception ex)
            {
                throw new MapException("MapUser - MapToDB", ex);
            }
        }

        public static User MapToDomain(UserEF userEF)
        {
            try
            {
                if (userEF == null)
                {
                    return null;
                }
                else
                {
                    User user = new User(userEF.Email);

                    List<Recipe> recipes = new List<Recipe>();
                    if (userEF.Recipes != null)
                    {
                        foreach (RecipeEF recipeEF in userEF.Recipes)
                        {
                            Recipe recipe = MapRecipe.MapToDomain(recipeEF);
                            recipes.Add(recipe);
                        }
                    }

                    user.Recipes = recipes;
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new MapException("MapUser - MapToDomain", ex);
            }
        }
    }
}