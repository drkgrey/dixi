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
        int depId;

		public Specialists(string name, int id)
		{
            InitializeComponent();

            depId = id;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = App.ConnectionString + $"api/Departament?name={name}";
            string res = httpClient.GetStringAsync(url).Result;
            var spec = JsonConvert.DeserializeObject<Doctor[]>(res);
            specList.ItemsSource = spec;
            specList.ItemTapped += SpecListItemTapped;
		}

        private void SpecListItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Doctor;
            if (item == null)
                return;
            Navigation.PushAsync(new DoctorView(item.Id, depId));
            ((ListView)sender).SelectedItem = null;
        }
    }
}