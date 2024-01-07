using Cooking.BL.Exceptions;
using Cooking.BL.Interfaces;
using Cooking.BL.Models;
using Cooking.EF.Exceptions;
using Cooking.EF.Mappers;
using Cooking.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.EF.Repositories
{
    public class RecipeRepositoryEF : IRecipeRepository
    {
        private readonly CookingContext _ctx;

        public RecipeRepositoryEF(string connectionString)
        {
            _ctx = new CookingContext(connectionString);
        }

        public void AddRecipe(int challengeId, string email, Recipe recipe)
        {
            try
            {
                UserEF uEF = _ctx.Users.Find(email);
                ChallengeEF cEF = _ctx.Challenges.Find(challengeId);

                RecipeEF newRecipe = MapRecipe.MapToDB(uEF, recipe);

                uEF.Recipes.Add(newRecipe);
                cEF.Recipes.Add(newRecipe);

                SaveAndClear();

                recipe.RecipeId = newRecipe.RecipeId;
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("AddRecipe", ex);
            }
        }

        public Recipe GetRecipeById(int recipeId)
        {
            try
            {
                RecipeEF recipeEF = _ctx.Recipes.Where(x => x.RecipeId == recipeId)
                    .Include(x => x.User)
                    .AsNoTracking()
                    .FirstOrDefault();

                return MapRecipe.MapToDomain(recipeEF);
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("GetRecipeById", ex);
            }
        }

        public bool RecipeExists(Recipe recipe)
        {
            try
            {
                return _ctx.Recipes.Any(x => x.RecipeName == recipe.RecipeName && x.RecipeDescription == recipe.Description);
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("UserExists", ex);
            }
        }

        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }
    }
}