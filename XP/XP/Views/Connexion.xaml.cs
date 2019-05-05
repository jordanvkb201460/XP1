﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Connexion : ContentPage
	{
		public Connexion ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        // Méthode lancée lorsque le bouton de connexion est utilisé
        private void ConnexionClicked(object sender, EventArgs e)
        {
            lblError.Text = "";
            //this.Navigation.PushAsync(new Experiences());
            ConnexionJson connexion = new ConnexionJson
            {
                username = pseudoUser.Text,
                password = pswdUser.Text,
            };
            var json = RestService.PostRequest<Participant>(connexion, "onsenfout");
            if(json == null)
            {
                lblError.Text = "Mauvais mdp";
            }
            else
            {
                User.Age = json.Age;
                User.Experiences = json.Experiences;
                User.Firstname = json.Firstname;
                User.Id = json.Id;
                User.Lastname = json.Lastname;
                User.Mail = json.Mail;
                User.Messages = json.Messages;
                User.ParticipationRequest = json.participationRequests;
                User.Sex = json.Sex;
                this.Navigation.PushAsync(new Experiences());
            }
            //var test = RestService.Save(json, "onsenfout");
            // Vérification si le pseudo et le mot de passe sont corrects
            //bool isPasswordOrUsernameCorrect = CheckConnexion();
            // Effectue la connexion si le booléen renvoie true
            // Connexion(isPasswordOrUsernameCorrect);
        }

        public void InscriptionClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Inscription());
        }
    }
}