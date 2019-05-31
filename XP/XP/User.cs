using System;
using System.Collections.Generic;
using System.Text;

namespace XP
{
    public class User 
    {

        private static User instance;

        private User()
        {

        }

        private User(Participant json)
        {
            User.instance = new User();
            User.instance.Experiences = json?.Experiences;
            User.instance.Firstname = json.Firstname;
            User.instance.Id = json.Id;
            User.instance.Lastname = json.Lastname;
            User.instance.Mail = json?.Mail;
            User.instance.Messages = json?.Messages;
            User.instance.ParticipationRequests = json?.participationRequests;
            User.instance.Sex = json.Sex;
            User.instance.Token = json.Token;
            User.instance.BirthDate = json.BirthDate;
        }

        public static User getInstance()
        {
            if (instance == null)
            {
                new User();
            }
            return instance;
        }

        public static User getInstance(Participant json)
        {
            if(instance == null)
            {
                new User(json);
            }
            return instance;
        }

       

        public static void EraseInstance()
        {
            User.instance = null;
        }

        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Mail { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Password { get; set; }

        public Experience[] Experiences { get; set; }

        public Message[] Messages { get; set; }

        public List<ParticipationRequest> ParticipationRequests { get; set; }

        public string Token { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
