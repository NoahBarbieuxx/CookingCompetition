namespace Cooking.REST.Models.Input
{
    public class ImageInput
    {
        public ImageInput(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        public string ImageUrl { get; set; }
    }
}