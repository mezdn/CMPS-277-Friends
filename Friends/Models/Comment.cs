using System;
using System.ComponentModel;

namespace Friends.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [DisplayName("Time of Creation")]
        public DateTime TimeOfCreationDate { get; set; }
        
        public long TimeOfCreation { get; set; }

        public string Content { get; set; }

        // FK to Person
        [DisplayName("From")]
        public string PersonUsername { get; set; }

        // FK to Post
        public int PostID { get; set; }
    }
}
