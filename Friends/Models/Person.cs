using System;
using System.ComponentModel;

namespace Friends.Models
{
    public class Person
    {
        public string Username { get; set; }

        // FK to Area of Expertise
        [DisplayName("Area of Expertise")]
        public string AreaOfExpertiseName { get; set; }

        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        
        [DisplayName("Date of Birth")]
        public long DateOfBirth { get; set; }

        public DateTime DateOfBirthDate { get; set; }
        
        public string Country { get; set; }
        
        public string Password { get; set; }

        // Not Mapped to the database
        public bool isFriend { get; set; }
    }
}
