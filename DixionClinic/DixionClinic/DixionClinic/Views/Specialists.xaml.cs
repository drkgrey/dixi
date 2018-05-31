using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Specialists : ContentPage
	{
		public Specialists(int id)
		{
			InitializeComponent ();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = App.ConnectionString + "api/Specialist";
            string res = httpClient.GetStringAsync(url).Result;
            var tmp = JsonConvert.DeserializeObject<Specialist[]>(res);
            var spec = tmp.Where(e => e.DepartamentId == id).ToArray();
            specList.ItemsSource = spec;
            specList.ItemTapped += SpecListItemTapped;
		}

        private void SpecListItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Specialist;
            if (item == null)
                return;
            Navigation.PushAsync(new DoctorView(item.DoctorId, item.Id));
            ((ListView)sender).SelectedItem = null;
        }
    }
}