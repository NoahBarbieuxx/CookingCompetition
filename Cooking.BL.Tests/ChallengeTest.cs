using Cooking.BL.Exceptions;
using Cooking.BL.Models;

namespace Cooking.BL.Tests
{
    public class ChallengeTest
    {

        [Fact]
        public void TestChallengeConstructorWithValidData()
        {
            var challengeId = 1;
            var challengeName = "Cooking Challenge";
            var description = "Description of the challenge";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(5);
            var recipes = new List<Recipe> {  };

            var challenge = new Challenge(challengeId, challengeName, description, startDate, endDate, recipes);

            Assert.Equal(challengeId, challenge.ChallengeId);
            Assert.Equal(challengeName, challenge.ChallengeName);
            Assert.Equal(description, challenge.Description);
            Assert.Equal(startDate, challenge.StartDate);
            Assert.Equal(endDate, challenge.EndDate);
            Assert.Equal(recipes, challenge.Recipes);
        }

        [Fact]
        public void TestChallengeConstructorWithInvalidChallengeId()
        {
            var challengeId = -1;

            Assert.Throws<ChallengeException>(() => new Challenge(challengeId, "Challenge", "Description", DateTime.Now.AddDays(1), DateTime.Now.AddDays(5), new List<Recipe>()));
        }

        [Fact]
        public void TestChallengeConstructorWithInvalidChallengeName()
        {
            var challengeName = " ";

            Assert.Throws<ChallengeException>(() => new Challenge(challengeName, "Description", DateTime.Now.AddDays(1), DateTime.Now.AddDays(5), new List<Recipe>()));
        }

        [Fact]
        public void TestChallengeConstructorWithInvalidDescription()
        {
            var description = " ";

            Assert.Throws<ChallengeException>(() => new Challenge("Challenge", description, DateTime.Now.AddDays(1), DateTime.Now.AddDays(5), new List<Recipe>()));
        }

        [Fact]
        public void TestChallengeConstructorWithPastStartDate()
        {
            var pastDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(-1);

            var exception = Record.Exception(() =>
            {
                var challenge = new Challenge("Challenge Name", "Description", pastDate, endDate, new List<Recipe>());
            });

            Assert.NotNull(exception);
            Assert.IsType<ChallengeException>(exception);
        }


        [Fact]
        public void TestChallengeConstructorWithEndDateBeforeStartDate()
        {
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now;

            Assert.Throws<ChallengeException>(() => new Challenge("Challenge", "Description", startDate, endDate, new List<Recipe>()));
        }
    }
}
