using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                Sex = sex.Text,
                BirthDate = birthdate.Date,
            };
            RestService.PostRequest<string>(pa,"inscriptionParticipant");
            this.Navigation.PopAsync();
        }
	}
}