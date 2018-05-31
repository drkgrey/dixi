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
    public partial class Directions : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        Direction[] dirs;

        public Directions()
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = App.ConnectionString + "api/Direction";
            string res = httpClient.GetStringAsync(url).Result;
            dirs = JsonConvert.DeserializeObject<Direction[]>(res);
            dirList.ItemsSource = dirs;
            dirList.ItemTapped += DirListItemSelected;
        }

        private void DirListItemSelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Direction;
            if (item == null)
                return;
            Navigation.PushAsync(new Departments(item.Id));
            ((ListView)sender).SelectedItem = null;
        }
    }
}