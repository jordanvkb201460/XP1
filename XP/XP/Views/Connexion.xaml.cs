using Newtonsoft.Json;
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

        private void ConnexionClicked(object sender, EventArgs e)
        {
            lblError.Text = "";
            ConnexionJson connexion = new ConnexionJson
            {
                username = pseudoUser.Text,
                password = pswdUser.Text,
            };
            var json = RestService.PostRequest<Participant>(connexion, "loginjson");
            if(json == null)
            {
                lblError.Text = "Adresse mail ou mot de passe incorrect";
            }
            else
            {
                User.getInstance(json);
                this.Navigation.PushAsync(new Experiences());
            }
        }

        public void InscriptionClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Inscription());
        }
    }
}