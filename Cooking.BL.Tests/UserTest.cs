using Cooking.BL.Exceptions;
using Cooking.BL.Models;

namespace Cooking.BL.Tests
{
    public class UserTest
    {
        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            var email = "test@example.com";
            var recipes = new List<Recipe>();

            var user = new User(email, recipes);

            Assert.Equal(email, user.Email);
            Assert.Equal(recipes, user.Recipes);
        }

        [Fact]
        public void OverloadedConstructor_WithValidEmail_InitializesEmail()
        {
            var user = new User("test@example.com");

            Assert.Equal("test@example.com", user.Email);
            Assert.Null(user.Recipes);
        }

        [Fact]
        public void Email_SetValidValue_AssignsValue()
        {
            var user = new User("initial@example.com");

            user.Email = "test@example.com";

            Assert.Equal("test@example.com", user.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("invalidemail")]
        public void Email_SetInvalidValue_ThrowsUserException(string invalidEmail)
        {
            var user = new User("valid@example.com");

            Assert.Throws<UserException>(() => user.Email = invalidEmail);
        }

        [Fact]
        public void Recipes_SetValidList_AssignsList()
        {
            var user = new User("test@example.com");
            var recipes = new List<Recipe>();

            user.Recipes = recipes;

            Assert.Equal(recipes, user.Recipes);
        }

        [Fact]
        public void Recipes_SetToNull_ThrowsRecipeException()
        {
            var user = new User("test@example.com");

            Assert.Throws<UserException>(() => user.Recipes = null);
        }
    }
}