using Cooking.BL.Exceptions;
using Cooking.BL.Models;

namespace Cooking.BL.Tests
{
    public class RecipeTest
    {

        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            var recipeId = 1;
            var recipeName = "Test Recipe";
            var description = "Test Description";
            var likes = new List<Like>();
            var user = new User("user@example.com");
            var images = new List<Image>();

            var recipe = new Recipe(recipeId, recipeName, description, likes, user, images);

            Assert.Equal(recipeId, recipe.RecipeId);
            Assert.Equal(recipeName, recipe.RecipeName);
            Assert.Equal(description, recipe.Description);
            Assert.Equal(likes, recipe.Likes);
            Assert.Equal(user, recipe.User);
            Assert.Equal(images, recipe.Images);
        }

        [Fact]
        public void OverloadedConstructor_WithValidParameters_InitializesProperties()
        {
            var recipeName = "Test Recipe";
            var description = "Test Description";

            var recipe = new Recipe(recipeName, description);

            Assert.Equal(recipeName, recipe.RecipeName);
            Assert.Equal(description, recipe.Description);
            Assert.Null(recipe.Likes);
            Assert.Null(recipe.User);
            Assert.Null(recipe.Images);
        }

        [Fact]
        public void RecipeId_SetValidValue_AssignsValue()
        {
            var recipe = new Recipe("Test", "Description");

            recipe.RecipeId = 10;

            Assert.Equal(10, recipe.RecipeId);
        }


        [Fact]
        public void RecipeId_SetInvalidValue_ThrowsRecipeException()
        {
            var recipe = new Recipe("Test", "Description");

            Assert.Throws<RecipeException>(() => recipe.RecipeId = 0);
        }


        [Fact]
        public void RecipeName_SetValidValue_AssignsValue()
        {
            var recipe = new Recipe("Initial Name", "Description");

            recipe.RecipeName = "Test Recipe";

            Assert.Equal("Test Recipe", recipe.RecipeName);
        }

        [Fact]
        public void RecipeName_SetInvalidValue_ThrowsRecipeException()
        {
            var recipe = new Recipe("Initial Name", "Description");

            Assert.Throws<RecipeException>(() => recipe.RecipeName = "");
        }
    }
}
