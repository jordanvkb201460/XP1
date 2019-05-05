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
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if(Compensation.Text != null)
            {
                dic.Add("Compensation", Compensation.Text);
            }
            if (Name.Text != null)
            {
                dic.Add("Name", Name.Text);
            }

            this.Navigation.PushAsync(new Experiences(dic));
        }
	}
}