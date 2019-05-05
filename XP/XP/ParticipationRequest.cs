using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class ParticipationRequest
    {
        public int id { get; set; }

        public int Validated { get; set; }

        public int IdParticipant { get; set; }

        public Experience IdExperience { get; set; }

        public ParticipationRequest()
        {
            this.IdExperience = new Experience();
        }
    }
}
