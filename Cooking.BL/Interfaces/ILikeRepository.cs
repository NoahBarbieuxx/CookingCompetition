using Cooking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Interfaces
{
    public interface ILikeRepository
    {
        // POST
        void AddLikeToRecipe(int recipeId, Like like);

        // GET
        List<Like> GetLikesByRecipeId(int recipeId);
    }
}