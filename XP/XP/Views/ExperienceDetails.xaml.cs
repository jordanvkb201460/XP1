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
	public partial class ExperienceDetails : ContentPage
	{
        int idExp;
		public ExperienceDetails (Experience exp)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            compensation.Text = exp.Compensation.ToString();
            nom.Text = exp.Name.ToString();
            lieu.Text = exp.Place.ToString();
            agereq.Text = exp.AgeReq?.ToString();
            SexReq.Text = exp.SexReq?.ToString();
            SpeReq.Text = exp.SpecifiqReq?.ToString();
            date.Text = exp.DateDebut.ToString();
            idExp = exp.id;
            bool check = false;
            foreach(ParticipationRequest tmp in User.ParticipationRequest)
            {
                if(tmp.IdExperience.id == this.idExp)
                {
                    switch (tmp.Validated)
                    {
                        case 1: uselessBouton.Text = "Inscription validée";
                            //rajouter une condition
                            feedback.Text = exp.Feedback; break;
                        case 2: uselessBouton.Text = "Inscription refusée"; break;
                        case 3: uselessBouton.Text = "Inscription en attente"; break;
                    }
                    check = true;
                    break;
                }
                else
                {

                }
            }
            if(check)
            {
                participationRq.IsEnabled = false;
                
            }
        }

        private void ParticipationRequest(object sender, EventArgs e)
        {
            ParticipationRequest pr = new ParticipationRequest
            {
                IdParticipant = User.Id,
                Validated = 3,
            };
            pr.IdExperience.id = this.idExp;
            RestService.PostRequest<string>(pr, "participationRequest");
            uselessBouton.Text = "demande d'inscription envoyée";
            participationRq.IsEnabled = false;
            User.ParticipationRequest.Add(pr);
        }
    }
}