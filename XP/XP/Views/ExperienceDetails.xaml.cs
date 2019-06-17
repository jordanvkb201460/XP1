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
            MainStack.BackgroundColor = Color.FromHex("#7cc8ff");
            compensation.Text = exp.Compensation.ToString() ?? "0" + "€";
            nom.VerticalTextAlignment = TextAlignment.Center;
            nom.HorizontalTextAlignment = TextAlignment.Start;
            if (exp.Name.ToString().Length > 15)
            {
                nom.FontSize = 12;
               
            }
            else if(exp.Name.ToString().Length > 60)
            {
                nom.FontSize = 9;
            }
            nom.Text = exp.Name.ToString();
            lieu.Text = exp.Place.ToString();
            agereq.Text = exp.AgeReq?.ToString() ?? "Pas d'âge requis" ;
            SexReq.Text = exp.SexReq?.ToString() ?? "Pas de sexe requis";
            SpeReq.Text = exp.SpecifiqReq?.ToString() ?? "Pas de critères spécifiques";
            date.Text = exp.DateDebut.ToString();
            dateFin.Text = exp.DateFin.ToString();
            idExp = exp.id;
            bool check = false;
            var tmp2 = User.getInstance();
            foreach(ParticipationRequest tmp in User.getInstance().ParticipationRequests)
            {
                if(tmp.IdExperience.id == this.idExp)
                {
                    switch (tmp.Status)
                    {
                        case 1: uselessBouton.Text = "Inscription validée";
                            feedback.Text = exp.Feedback; 
                            break;
                        case 2: uselessBouton.Text = "Inscription refusée";
                            feedback.Text = "Attention, vous ne remplissez pas les critères requis pour cette expérience";
                            break;
                        case 0: uselessBouton.Text = "Inscription en attente"; break;
                        default: uselessBouton.Text = "Experience terminée";
                            feedback.Text = exp.Feedback;
                            break;
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
                Status = 0, 
                IdParticipant = User.getInstance().Token,
                Validated = 3,
            };
            Experience tmp = new Experience();
            tmp.id = this.idExp;
            pr.IdExperience = tmp;
            RestService.PostRequest<string>(pr, "participationRequest");
            uselessBouton.Text = "demande d'inscription envoyée";
            participationRq.IsEnabled = false;
            User.getInstance().ParticipationRequests.Add(pr);
        }
    }
}