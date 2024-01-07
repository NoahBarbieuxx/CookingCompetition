using Cooking.BL.Models;

namespace Cooking.BL.Interfaces
{
    public interface IRecipeRepository
    {
        // POST
        void AddRecipe(int challengeId, string email, Recipe recipe);

        // GET
        Recipe GetRecipeById(int recipeId);

        // ANDERE
        bool RecipeExists(Recipe recipe);
    }
}