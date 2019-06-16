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
    public partial class ExperiencesUser : ContentPage
    {
        public ExperiencesUser(List<Experience> experiences)
        {
            InitializeComponent();
            List<int> idExp =  new List<int>();
            List<ParticipationRequest> participationRq = User.getInstance().ParticipationRequests;
            foreach (ParticipationRequest pr in participationRq)
            {
                idExp.Add(pr.IdExperience.id);
            }
            foreach (Experience exp in experiences)
            {
                if (exp.IsActive && idExp.Contains(exp.id))
                {
                    Label lbl = new Label()
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(10),
                        Text = exp.Name
                    };

                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    Image img = new Image
                    {
                        Margin = new Thickness(5, 5),
                        HeightRequest = 75,
                        WidthRequest = 75
                    };
                    ParticipationRequest tmp = participationRq.Find(x => x.IdExperience.id == exp.id);
                    switch(tmp.Status)
                    {
                        case 0 :img.Source = "sablier2";break;
                        case 1: img.Source = "check"; break;
                        case 2: img.Source = "redcross"; break;
                        case 3: img.Source = "lock"; break;
                        case 4: img.Source = "lock"; break;
                        default: img.Source = "test";break;
                    }
                    tap.Tapped += (s, e) => Details(s, e, exp);
                    img.GestureRecognizers.Add(tap);
                    lbl.GestureRecognizers.Add(tap);
                    StackLayout frame = new StackLayout()
                    {
                        HeightRequest = 100,
                        Orientation = StackOrientation.Horizontal,
                        Margin = new Thickness(2, 2),
                        BackgroundColor = Color.Gray,
                    };
                    frame.Children.Add(img);
                    frame.Children.Add(lbl);
                    ExpStack.Children.Add(frame);
                }
            }
        }

        public void Details(object sender, EventArgs e, Experience exp)
        {
            // List<Experience> list = RestService.RequestTest<List<Experience>>();
            this.Navigation.PushAsync(new ExperienceDetails(exp));
        }
    }
}