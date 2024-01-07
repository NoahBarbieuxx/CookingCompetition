using Cooking.BL.Exceptions;
using Cooking.BL.Managers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static System.Net.Mime.MediaTypeNames;

namespace Cooking.BL.Models
{
    public class Recipe
    {
        public Recipe(int recipeId, string recipeName, string description, List<Like> likes, User user, List<Image> images)
        {
            RecipeId = recipeId;
            RecipeName = recipeName;
            Description = description;
            Likes = likes;
            User = user;
            Images = images;
        }

        public Recipe(string recipeName, string description, List<Like> likes, User user, List<Image> images)
        {
            RecipeName = recipeName;
            Description = description;
            Likes = likes;
            User = user;
            Images = images;
        }

        public Recipe(int recipeId, string recipeName, string description)
        {
            RecipeName = recipeName;
            Description = description;
            RecipeId = recipeId;
        }

        public Recipe(string recipeName, string description)
        {
            RecipeName = recipeName;
            Description = description;
        }

        private int _recipeId;
        public int RecipeId
        {
            get
            {
                return _recipeId;
            }
            set
            {
                if (value <= 0)
                {
                    throw new RecipeException("RecipeId is invalid! (Must be greater than 0)");
                }
                else
                {
                    _recipeId = value;
                }
            }
        }

        private string _recipeName;
        public string RecipeName
        {
            get
            {
                return _recipeName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new RecipeException("RecipeName is invalid! (Must be a filled string)");
                }
                else
                {
                    _recipeName = value;
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
                    throw new RecipeException("RecipeDescription is invalid! (Must be a filled string)");
                }
                else
                {
                    _description = value;
                }
            }
        }

        private List<Like> _likes;
        public List<Like> Likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
            }
        }

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value == null)
                {
                    throw new RecipeException("User is invalid! (Must be a valid user)");
                }
                else
                {
                    _user = value;
                }
            }
        }

        private List<Image> _images;
        public List<Image> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
            }
        }
    }
}