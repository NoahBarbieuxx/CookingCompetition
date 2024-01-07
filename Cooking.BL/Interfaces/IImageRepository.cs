using Cooking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Interfaces
{
    public interface IImageRepository
    {
        // POST
        void AddImagesToRecipe(int recipeId, Image images);

        // GET
        List<Image> GetImagesFromRecipe(int recipeId);
    }
}