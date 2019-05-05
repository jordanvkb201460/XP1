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
		public Experiences (Dictionary<string,string> dic=null)
		{
			InitializeComponent ();
            List<Experience> list = new List<Experience>(RestService.Request<List<Experience>>());
            if(dic != null && dic.Count != 0)
            {
               list = Sort(list, dic);
            }
            foreach (Experience exp in list)
            {
                if(!exp.IsActive)
                {

                }
                else
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
                    StackLayout frame = new StackLayout()
                    {
                        HeightRequest = 100,
                        Orientation = StackOrientation.Horizontal
                    };
                    frame.Children.Add(img);
                    frame.Children.Add(lbl);
                    ExpStack.Children.Add(frame);
                }
               
            }
        }

        private List<Experience> Sort(List<Experience> list, Dictionary<string, string> dic)
        {
            IEnumerable<Experience> tmpList = list;
            foreach (KeyValuePair<string,string> kvp in dic)
            {
                
              tmpList = list.Where(x => x.GetType().GetProperty(kvp.Key).GetValue(x).ToString() == kvp.Value);

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
    }
}