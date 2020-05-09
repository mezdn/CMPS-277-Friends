using System;
using System.ComponentModel;

namespace Friends.Models
{
    public class Post
    {
        public int ID { get; set; }
        
        [DisplayName("Time of Creation")]
        public DateTime TimeOfCreationDate { get; set; }

        public long TimeOfCreation { get; set; }

        public string Content { get; set; }

        // FK to Person
        [DisplayName("Owner")]
        public string PersonUsername { get; set; }

        // FK to Group
        public int GroupID { get; set; }

        public string Group { get; set; }

        // Not Mapped to the Database
        [DisplayName("Category")]
        public string CategoryName { get; set; }
    }
}
