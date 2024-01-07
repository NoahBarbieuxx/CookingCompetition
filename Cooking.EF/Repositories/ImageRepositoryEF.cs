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
    public class ImageRepositoryEF : IImageRepository
    {
        private readonly CookingContext _ctx;

        public ImageRepositoryEF(string connectionString)
        {
            _ctx = new CookingContext(connectionString);
        }

        public void AddImagesToRecipe(int recipeId, Image images)
        {
            try
            {
                RecipeEF recipeEF = _ctx.Recipes.Include(x => x.Images).FirstOrDefault(x => x.RecipeId == recipeId);

                ImageEF imageEF = MapImage.MapToDB(images);

                recipeEF.Images.Add(imageEF);
                _ctx.Images.Add(imageEF);

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new ImageRepositoryException("AddImagesToRecipe", ex);
            }
        }

        public List<Image> GetImagesFromRecipe(int recipeId)
        {
            try
            {
                RecipeEF recipeEF = _ctx.Recipes.Include(x => x.Images).Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.RecipeId == recipeId);

                Recipe recipeCorrect = MapRecipe.MapToDomain(recipeEF);

                if (recipeCorrect == null)
                {
                    return null;
                }
                else
                {
                    return recipeCorrect.Images;
                }
            }
            catch (Exception ex)
            {
                throw new ImageRepositoryException("GetImagesFromRecipe", ex);
            }
        }

        private void SaveAndClear()
        {
            _ctx.SaveChanges();
            _ctx.ChangeTracker.Clear();
        }
    }
}