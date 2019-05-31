using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class ParticipationRequest
    {
        public int id { get; set; }

        public int Validated { get; set; }

        public string IdParticipant { get; set; }

        public Experience IdExperience { get; set; }

        public int Status { get; set; }

        public ParticipationRequest()
        {
            
        }
    }
}
