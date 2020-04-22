using System;

namespace Friends.Models
{
    public class Group
    {
        public int ID { get; set; }
        
        // FKto Person
        public string AdminId{ get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
