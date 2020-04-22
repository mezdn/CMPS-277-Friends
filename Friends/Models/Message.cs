using System;

namespace Friends.Models
{
    public class Message
    {
        public int ID { get; set; }

        // FK to Person
        public string SenderId { get; set; }

        // FK to Person
        public string RecieverId { get; set; }

        public DateTime TimeOfSending { get; set; }

        public string Content { get; set; }
    }
}
