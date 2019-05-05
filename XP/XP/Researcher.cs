using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class Researcher
    {
        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Mail { get; set; }

        public string Department { get; set; }

        public string Status { get; set; }

        public Experience[] experiences { get; set; }

        public Message[] messages { get; set; }

        public string Password { get; set; }

        
    }
}
