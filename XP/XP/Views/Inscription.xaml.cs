using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inscription : ContentPage
	{
		public Inscription ()
		{
			InitializeComponent ();
            sex.Items.Add("M");
            sex.Items.Add("F");
        }

        public void InscriptionCheckAsync(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new Experiences());
            Participant pa = new Participant
            {
                Firstname = firstname.Text,
                Lastname = lastname.Text,
                Mail = mail.Text,
                Password = password.Text,
                Sex = sex.SelectedItem.ToString(),
                BirthDate = birthdate.Date,
            };
            if(!password.Text.Equals(password2.Text))
            {
                lblError.Text ="Les 2 mots de passe ne correspondent pas";
            }
            else
            {
                try
                {
                    new MailAddress(mail.Text);
                    RestService.PostRequest<string>(pa, "inscriptionParticipant");
                    this.Navigation.PopAsync();
                }
                catch (Exception exc)
                {
                    lblError.Text = "L'adresse mail n'est pas valide";
                }
            }
        }
	}
}