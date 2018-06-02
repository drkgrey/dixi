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
	public partial class Departments : ContentPage
	{
        public Departments(int id)
        {
            InitializeComponent();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = App.ConnectionString + "api/Departament";
            string res = httpClient.GetStringAsync(url).Result;
            var tmp = JsonConvert.DeserializeObject<Department[]>(res);
            var deps = tmp.Where(e => e.DirectionId == id).ToArray();
            depList.ItemsSource = deps;
            depList.ItemTapped += DepListItemSelected;
        }

        private void DepListItemSelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Department;
            if (item == null)
                return;
            Navigation.PushAsync(new Specialists(item.Name, item.Id));
            ((ListView)sender).SelectedItem = null;
        }
    }
}