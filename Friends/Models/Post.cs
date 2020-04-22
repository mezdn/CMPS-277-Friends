using System;

namespace Friends.Models
{
    public class Post
    {
        public int ID { get; set; }
        
        public DateTime TimeOfCreation { get; set; }

        public string Content { get; set; }

        // FK to Person
        public string PersonId { get; set; }

        // FK to Group
        public int GroupID { get; set; }
    }
}
