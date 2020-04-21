namespace Friends.Models.Relations
{
    public class PostCategory
    {
        // FK to Post
        public int PostID { get; set; }

        // FK to Category
        public int CategoryID { get; set; }
    }
}
