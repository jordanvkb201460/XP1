using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class Participant
    {
        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Mail { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Password { get; set; }

        public Experience[] Experiences { get; set; }

        public Message[] Messages { get; set; }

        public List<ParticipationRequest> participationRequests { get; set; }

        public string Token { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
