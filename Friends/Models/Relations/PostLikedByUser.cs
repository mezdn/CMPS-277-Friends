namespace Friends.Models.Relations
{
    public class PostLikedByUser
    {
        public Post Post { get; set; }

        public bool LikedByUser { get; set; }
    }
}
