using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Content { get; set; }

        public Researcher Sender { get; set; }

        public Participant[] Receiver { get; set; }

        public Experience InRelationWith { get; set; }
    }
}
