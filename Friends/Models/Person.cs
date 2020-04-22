using System;

namespace Friends.Models
{
    public class Person
    {
        // Primary Key: Added by Mohammed
        public int Id { get; set; }

        public string Username { get; set; }

        // FK to Area of Expertise
        public string AreaOfExpertiseName { get; set; }

        public string DisplayName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public string Country { get; set; }
        
        public string Password { get; set; }
    }
}
