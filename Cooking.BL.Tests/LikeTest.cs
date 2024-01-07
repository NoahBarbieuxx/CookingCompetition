using Cooking.BL.Exceptions;
using Cooking.BL.Models;

namespace Cooking.BL.Tests
{
    public class LikeTest
    {
        [Fact]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            var likeId = 1;
            var likeDate = DateTime.Now;

            var like = new Like(likeId, likeDate);

            Assert.Equal(likeId, like.LikeId);
            Assert.True((like.LikeDate - likeDate).TotalMilliseconds < 1000);
        }

        [Fact]
        public void OverloadedConstructor_WithValidParameters_InitializesProperties()
        {
            var likeDate = DateTime.Now;

            var like = new Like(likeDate);

            Assert.True((like.LikeDate - likeDate).TotalMilliseconds < 1000);
        }

        [Fact]
        public void LikeId_SetValidValue_AssignsValue()
        {
            var like = new Like(DateTime.Now);

            like.LikeId = 10;

            Assert.Equal(10, like.LikeId);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void LikeId_SetInvalidValue_ThrowsLikeException(int invalidLikeId)
        {
            var like = new Like(DateTime.Now);

            Assert.Throws<LikeException>(() => like.LikeId = invalidLikeId);
        }
    }
}