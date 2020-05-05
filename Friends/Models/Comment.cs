using System;

namespace Friends.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public long TimeOfCreation { get; set; }

        public string Content { get; set; }

        // FK to Person
        public string PersonUsername { get; set; }

        // FK to Post
        public int PostID { get; set; }
    }
}
