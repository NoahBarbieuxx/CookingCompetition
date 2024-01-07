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
    public class LikeControllerTest
    {
        private readonly Mock<ILikeRepository> mockLikeRepository;
        private readonly LikeManager likeManager;
        private readonly LikeController likeController;

        public LikeControllerTest()
        {
            mockLikeRepository = new Mock<ILikeRepository>();
            // Initialize LikeManager with the mocked repository
            likeManager = new LikeManager(mockLikeRepository.Object);
            // Initialize LikeController with the real LikeManager
            likeController = new LikeController(likeManager);
        }

        [Fact]
        public void AddLikeToRecipe_ReturnsLike_WhenAddIsSuccessful()
        {
            // Arrange
            int recipeId = 1;
            var likeInput = new LikeInput { /* Initialize with necessary data */ };
            var like = new Like(DateTime.Now);
            mockLikeRepository.Setup(repo => repo.AddLikeToRecipe(recipeId, like));

            // Act
            var result = likeController.AddLikeToRecipe(recipeId, likeInput);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Like>(okResult.Value);
            Assert.NotNull(returnValue);
        }

        [Fact]
        public void GetLikesByRecipeId_ReturnsLikes_WhenLikesExist()
        {
            // Arrange
            int recipeId = 1;
            var likes = new List<Like> { new Like(DateTime.Now), new Like(DateTime.Now) };
            mockLikeRepository.Setup(repo => repo.GetLikesByRecipeId(recipeId)).Returns(likes);

            // Act
            var result = likeController.GetLikesByRecipeId(recipeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Like>>(okResult.Value);
            Assert.Equal(likes.Count, returnValue.Count);
        }

    }
}