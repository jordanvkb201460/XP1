using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class User
    {
        public static int Id { get; set; }

        public static string Lastname { get; set; }

        public static string Firstname { get; set; }

        public static string Mail { get; set; }

        public static int Age { get; set; }

        public static string Sex { get; set; }

        public static string Password { get; set; }

        public static Experience[] Experiences { get; set; }

        public static Message[] Messages { get; set; }

        public static List<ParticipationRequest> ParticipationRequest { get; set; }
    }
}
