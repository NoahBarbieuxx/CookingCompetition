using Cooking.BL.Exceptions;
using Cooking.BL.Models;

namespace Cooking.BL.Tests
{
    public class ImageTests
    {
        [Fact]
        public void TwoParameterConstructor_WithValidParameters_InitializesProperties()
        {
            var imageId = 1;
            var imageUrl = "http://example.com/image.jpg";

            var image = new Image(imageId, imageUrl);

            Assert.Equal(imageId, image.ImageId);
            Assert.Equal(imageUrl, image.ImageUrl);
        }

        [Fact]
        public void OneParameterConstructor_WithValidUrl_InitializesImageUrl()
        {
            var imageUrl = "http://example.com/image.jpg";

            var image = new Image(imageUrl);

            Assert.Equal(imageUrl, image.ImageUrl);
        }

        [Fact]
        public void ImageId_SetValidValue_AssignsValue()
        {
            var image = new Image("http://example.com/image.jpg");

            image.ImageId = 10;

            Assert.Equal(10, image.ImageId);
        }

        [Fact]
        public void ImageId_SetInvalidValue_ThrowsImageException()
        {
            var image = new Image("http://example.com/image.jpg");

            Assert.Throws<ImageException>(() => image.ImageId = 0);
        }

        [Fact]
        public void ImageUrl_SetValidValue_AssignsValue()
        {
            var image = new Image(1, "http://example.com/initial.jpg");

            image.ImageUrl = "http://example.com/new.jpg";

            Assert.Equal("http://example.com/new.jpg", image.ImageUrl);
        }
    }
}
