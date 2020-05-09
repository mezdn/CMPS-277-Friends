using System;
using System.ComponentModel;

namespace Friends.Models
{
    public class Group
    {
        public int ID { get; set; }
        
        // FKto Person
        [DisplayName("Admin")]
        public string AdminUsername { get; set; }

        public string Name { get; set; }

        public long DateOfCreation { get; set; }

        [DisplayName("Date of Creation")]
        public DateTime DateOfCreationDate { get; set; }
    }
}
