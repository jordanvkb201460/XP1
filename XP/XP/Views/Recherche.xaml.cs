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
	public partial class Recherche : ContentPage
	{
		public Recherche ()
		{
			InitializeComponent ();
		}

        public void RechercheButton(object senders, EventArgs e)
        {
            Dictionary<string, FilterHelper> dic = new Dictionary<string, FilterHelper>();
            if(Compensation.Text != null)
            {
                dic.Add("Compensation",new FilterHelper(){
                  Value = Compensation.Text,
                  Method = "GreaterOrEquals"
                });
            }
            if (Name.Text != null)
            {
                dic.Add("Name", new FilterHelper()
                {
                    Value = Name.Text,
                    Method = "Contains"
                });

            }

            this.Navigation.PushAsync(new Experiences(dic));
        }
	}
}