using Cooking.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Models
{
    public class Challenge
    {
        public Challenge()
        {

        }

        public Challenge(int challengeId, string challengeName, string description, DateTime startDate, DateTime endDate, List<Recipe> recipes)
        {
            ChallengeId = challengeId;
            ChallengeName = challengeName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Recipes = recipes;
        }

        public Challenge(string challengeName, string description, DateTime startDate, DateTime endDate, List<Recipe> recipes)
        {
            ChallengeName = challengeName;
            Description= description;
            StartDate = startDate;
            EndDate = endDate;
            Recipes = recipes;
        }

        private int _challengeId;
        public int ChallengeId
        {
            get
            {
                return _challengeId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ChallengeException("ChallengeId is invalid! (Must be greater than 0)");
                }
                else
                {
                    _challengeId = value;
                }
            }
        }

        private string _challengeName;
        public string ChallengeName
        {
            get
            {
                return _challengeName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ChallengeException("ChallengeName is invalid! (Must be a filled string)");
                }
                else
                {
                    _challengeName = value;
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ChallengeException("Description is invalid! (Must be a filled string)");
                }
                else
                {
                    _description = value;
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value < StartDate)
                {
                    throw new ChallengeException("EndDate is invalid! (Date must be greater than the StartDate)");
                }
                else
                {
                    _endDate = value;
                }
            }
        }

        private List<Recipe> _recipes;
        public List<Recipe> Recipes
        {
            get
            {
                return _recipes;
            }
            set
            {
                _recipes = value;
            }
        }
    }
}