using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class Experience
    {
        public int id { get; set; }
        
        public float? Compensation { get; set; }

        public string Place { get; set; }

        public string Feedback { get; set; }

        public bool FreeReq { get; set; }

        public int? AgeReq { get; set; }

        public string SexReq { get; set; }

        public string SpecifiqReq { get; set; }

        public Researcher Researcher { get; set; }

        public Participant[] Participants { get; set; }

        public Message[] Messages { get; set; }

        public string Name { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public bool IsActive { get; set; }
    }
}
