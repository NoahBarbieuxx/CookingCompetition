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
    public class ImageManager
    {
        private readonly IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void AddImagesToRecipe(int recipeId, Image images)
        {
            try
            {
                _imageRepository.AddImagesToRecipe(recipeId, images);
            }
            catch (Exception ex)
            {
                throw new ImageManagerException("AddImagesToRecipe", ex);
            }
        }

        public List<Image> GetImagesFromRecipe(int recipeId)
        {
            try
            {
                return _imageRepository.GetImagesFromRecipe(recipeId);
            }
            catch (Exception ex)
            {
                throw new ImageManagerException("GetImagesFromRecipe", ex);
            }
        }
    }
}