using System;
using System.ComponentModel;

namespace Friends.Models
{
    public class Message
    {
        public int ID { get; set; }

        // FK to Person
        [DisplayName("Sender")]
        public string SenderUsername { get; set; }

        // FK to Person
        [DisplayName("Reciever")]
        public string RecieverUsername { get; set; }

        [DisplayName("Time of Sending")]
        public DateTime TimeOfSendingDate { get; set; }

        public long TimeOfSending { get; set; }

        public string Content { get; set; }
    }
}
