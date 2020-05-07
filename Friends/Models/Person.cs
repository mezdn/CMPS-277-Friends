using System;

namespace Friends.Models
{
    public class Person
    {
        public string Username { get; set; }

        // FK to Area of Expertise
        public string AreaOfExpertiseName { get; set; }

        public string DisplayName { get; set; }
        
        public long DateOfBirth { get; set; }
        
        public string Country { get; set; }
        
        public string Password { get; set; }

        // Not Mapped to the database
        public bool isFriend { get; set; }
    }
}
