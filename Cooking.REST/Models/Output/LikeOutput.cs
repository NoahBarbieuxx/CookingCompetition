namespace Cooking.REST.Models.Output
{
    public class LikeOutput
    {
        public LikeOutput(int likeId, DateTime likeDate)
        {
            LikeId = likeId;
            LikeDate = likeDate;
        }

        public int LikeId { get; set; }
        public DateTime LikeDate { get; set; }
    }
}