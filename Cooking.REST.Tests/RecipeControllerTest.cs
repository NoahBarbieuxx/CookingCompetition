using Cooking.BL.Interfaces;
using Cooking.BL.Managers;
using Cooking.BL.Models;
using Cooking.REST.Controllers;
using Cooking.REST.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.REST.Tests
{
    public class RecipeControllerTest
    {
        private readonly Mock<IRecipeRepository> mockRecipeRepository;
        private readonly Mock<IChallengeRepository> mockChallengeRepository;
        private readonly Mock<IUserRepository> mockUserRepository;
        private readonly RecipeManager recipeManager;
        private readonly ChallengeManager challengeManager;
        private readonly UserManager userManager;
        private readonly RecipeController recipeController;

        public RecipeControllerTest()
        {
            mockRecipeRepository = new Mock<IRecipeRepository>();
            // Initialize RecipeManager, ChallengeManager, and UserManager with the mocked repositories
            recipeManager = new RecipeManager(mockRecipeRepository.Object);
            challengeManager = new ChallengeManager(mockChallengeRepository.Object);
            userManager = new UserManager(mockUserRepository.Object);
            // Initialize RecipeController with the real RecipeManager
            recipeController = new RecipeController(recipeManager, challengeManager, userManager);
        }

        [Fact]
        public void AddRecipeToChallenge_ValidInput_ReturnsOk()
        {
            // Arrange
            int challengeId = 1;
            string email = "user@example.com";
            var recipeInput = new RecipeInput("New Recipe", "Description");

            // Mock the behavior of _recipeManager.AddRecipe to indicate success
            mockRecipeRepository.Setup(manager => manager.AddRecipe(challengeId, email, It.IsAny<Recipe>()));

            // Act
            var result = recipeController.AddRecipeToChallenge(challengeId, email, recipeInput);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void AddRecipeToChallenge_AddingFails_ReturnsBadRequest()
        {
            // Arrange
            int challengeId = 1;
            string email = "user@example.com";
            var recipeInput = new RecipeInput("New Recipe", "Description");

            // Mock the behavior of _recipeManager.AddRecipe to throw an exception
            mockRecipeRepository.Setup(manager => manager.AddRecipe(challengeId, email, It.IsAny<Recipe>()))
                             .Throws(new Exception("Adding recipe failed"));

            // Act
            var result = recipeController.AddRecipeToChallenge(challengeId, email, recipeInput);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}