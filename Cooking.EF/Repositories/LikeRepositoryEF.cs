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
    public class LikeRepositoryEF : ILikeRepository
    {
        private readonly CookingContext _ctx;

        public LikeRepositoryEF(string connectionString)
        {
            _ctx = new CookingContext(connectionString);
        }

        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }

        public void AddLikeToRecipe(int recipeId, Like like)
        {
            try
            {
                RecipeEF recipeEF = _ctx.Recipes.FirstOrDefault(x => x.RecipeId == recipeId);

                LikeEF likeEF = MapLike.MapToDB(like);
                recipeEF.Likes.Add(likeEF);

                SaveAndClear();

                like.LikeId = likeEF.LikeId;
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("AddLikeToRecipe", ex);
            }
        }

        public List<Like> GetLikesByRecipeId(int recipeId)
        {
            try
            {
                RecipeEF recipeEF = _ctx.Recipes
                    .Include(x => x.Likes)
                    .FirstOrDefault(x => x.RecipeId == recipeId);

                List<Like> likes = recipeEF.Likes.Select(MapLike.MapToDomain).ToList();

                return likes;
            }
            catch (Exception ex)
            {
                throw new RecipeRepositoryException("GetLikesByRecipeId", ex);
            }
        }
    }
}