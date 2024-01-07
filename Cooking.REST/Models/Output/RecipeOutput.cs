using Cooking.BL.Models;
using Cooking.EF.Models;

namespace Cooking.REST.Models.Output
{
    public class RecipeOutput
    {
        public RecipeOutput(int recipeId, string recipeName, string recipeDescription, User user, List<Image> images)
        {
            RecipeId = recipeId;
            RecipeName = recipeName;
            RecipeDescription = recipeDescription;
            User = user;
            Images = images;
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public User User { get; set; }
    }
}