using Cooking.BL.Exceptions;
using Cooking.BL.Interfaces;
using Cooking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.BL.Managers
{
    public class LikeManager
    {
        private readonly ILikeRepository _likeRepository;

        public LikeManager(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public void AddLikeToRecipe(int recipeId, Like like)
        {
            try
            {
                _likeRepository.AddLikeToRecipe(recipeId, like);
            }
            catch (Exception ex)
            {
                throw new LikeManagerException("AddLikeToRecipe", ex);
            }
        }

        public List<Like> GetLikesByRecipeId(int recipeId)
        {
            try
            {
                return _likeRepository.GetLikesByRecipeId(recipeId);
            }
            catch (Exception ex)
            {
                throw new LikeManagerException("GetLikesByRecipeId", ex);
            }
        }
    }
}