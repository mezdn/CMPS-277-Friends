namespace Friends.Models.Relations
{
    public class Like
    {
        // FK to Post
        public int PostID { get; set; }

        // FK to Person
        public string PersonUsername { get; set; }
    }
}
