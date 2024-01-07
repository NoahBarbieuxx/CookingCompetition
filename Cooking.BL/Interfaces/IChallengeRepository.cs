using Cooking.BL.Models;

namespace Cooking.BL.Interfaces
{
    public interface IChallengeRepository
    {
        // POST
        void AddChallenge(Challenge challenge);

        // GET
        List<Challenge> GetAllChallenges();
        Challenge GetChallengeById(int challengeId);
    }
}