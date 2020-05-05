using System;

namespace Friends.Models
{
    public class Group
    {
        public int ID { get; set; }
        
        // FKto Person
        public string AdminUsername { get; set; }

        public string Name { get; set; }

        public long DateOfCreation { get; set; }
    }
}
