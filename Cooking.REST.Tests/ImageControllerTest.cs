using Cooking.BL.Interfaces;
using Cooking.BL.Managers;
using Cooking.BL.Models;
using Cooking.REST.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.REST.Tests
{
    public class ImageControllerTest
    {
        private readonly Mock<IImageRepository> mockImageRepository;
        private readonly ImageManager imageManager;
        private readonly ImageController imageController;

        public ImageControllerTest()
        {
            mockImageRepository = new Mock<IImageRepository>();
            // Initialize ImageManager with the mocked repository
            imageManager = new ImageManager(mockImageRepository.Object);
            // Initialize ImageController with the real ImageManager
            imageController = new ImageController(imageManager);
        }

        [Fact]
        public void GetImageByRecipeId_ReturnsImages_WhenImagesExist()
        {
            // Arrange
            var recipeId = 1;
            var images = new List<Image> { new Image("imageUrl1"), new Image("imageUrl2") };
            mockImageRepository.Setup(manager => manager.GetImagesFromRecipe(recipeId)).Returns(images);

            // Act
            var result = imageController.GetImageByRecipeId(recipeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Image>>(okResult.Value);
            Assert.Equal(images.Count, returnValue.Count);
        }

        // ik kan dit niet testen door opslaan van image in loacle omgeving

        //[Fact]
        //public async Task AddImage_ReturnsOk_WhenImageIsAdded()
        //{
        //    // Arrange
        //    var recipeId = 1;
        //    var mockFile = new Mock<IFormFile>();
        //    var imagePath = Path.Combine("Images", Guid.NewGuid().ToString() + ".png");

        //    mockFile.Setup(_ => _.FileName).Returns(imagePath);
        //    mockImageRepository.Setup(manager => manager.AddImagesToRecipe(It.IsAny<int>(), It.IsAny<Image>()));

        //    // Act
        //    var result = await imageController.AddImage(mockFile.Object, recipeId);

        //    // Assert
        //    var objectResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        //}
    }
}
