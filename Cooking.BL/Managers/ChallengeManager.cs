using Cooking.BL.Exceptions;
using Cooking.BL.Interfaces;
using Cooking.BL.Models;

namespace Cooking.BL.Managers
{
    public class ChallengeManager
    {
        private readonly IChallengeRepository _challengeRepository;

        public ChallengeManager(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }

        public void AddChallenge(Challenge challenge)
        {
            try
            {
                _challengeRepository.AddChallenge(challenge);
            }
            catch (Exception ex)
            {
                throw new ChallengeManagerException("AddChallenge", ex);
            }
        }

        public List<Challenge> GetAllChallenges()
        {
            try
            {
                return _challengeRepository.GetAllChallenges();
            } 
            catch (Exception ex)
            {
                throw new ChallengeManagerException("GetAllChallenges", ex);
            }
        }

        public Challenge GetChallengeById(int challengeId)
        {
            try
            {
                return _challengeRepository.GetChallengeById(challengeId);
            }
            catch (Exception ex)
            {
                throw new ChallengeManagerException("GetChallengeById", ex);
            }
        }
    }
}