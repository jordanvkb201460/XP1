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
            int tmpAge;
            Int32.TryParse(age.Text, out tmpAge);
            Participant pa = new Participant
            {
                Firstname = firstname.Text,
                Lastname = lastname.Text,
                Age = tmpAge,
                Mail = mail.Text,
                Password = password.Text,
                Sex = sex.Text,
            };
            string paJson = JsonConvert.SerializeObject(pa);
            RestService.PostRequest<string>(paJson,"inscriptionParticipant");
        }
	}
}