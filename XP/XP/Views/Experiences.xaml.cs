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
	public partial class Experiences : ContentPage
	{
        List<Experience> list;

        public Experiences (Dictionary<string,FilterHelper> dic=null)
		{
			InitializeComponent ();
            list = new List<Experience>(RestService.Request<List<Experience>>());
            if(dic != null && dic.Count != 0)
            {
               list = Sort(list, dic);
            }
            foreach (Experience exp in list)
            {
                if(exp.IsActive)
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
                        Source = "test.jpg",
                        Margin = new Thickness(5, 5)
                    };
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

        private List<Experience> Sort(List<Experience> list, Dictionary<string, FilterHelper> dic)
        {
            IEnumerable<Experience> tmpList = list;
            foreach (KeyValuePair<string,FilterHelper> kvp in dic)
            {
               if(kvp.Value.Method.Equals("GreaterOrEquals"))
               {
                   int a = Int32.Parse(kvp.Value.Value);
                   tmpList = list.Where(x =>  Convert.ToInt32(x.GetType().GetProperty(kvp.Key).GetValue(x)) >=  a);
               }
               else if (kvp.Value.Method.Equals("Contains"))
               {
                   tmpList = list.Where(x => x.GetType().GetProperty(kvp.Key).GetValue(x).ToString().Contains(kvp.Value.Value));
               }
            }
            return tmpList.ToList<Experience>();
        }
           

        public void Details(object sender, EventArgs e, Experience exp)
        {
           // List<Experience> list = RestService.RequestTest<List<Experience>>();
            this.Navigation.PushAsync(new ExperienceDetails(exp));
        }

        public void Recherche(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Recherche());
        }

        public void ExperienceUser(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ExperiencesUser(list));
        }

        public void Logout(object sender, EventArgs e)
        {
            RestService.PostRequest<string>(new Token(User.getInstance().Token), "logoutjson");
            User.EraseInstance();
            this.Navigation.PopToRootAsync();
        }
    }
}