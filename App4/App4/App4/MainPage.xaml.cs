using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();

            string url = "http://arkonlab.website/api/Doctor/32";

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            string res;
            res = httpClient.GetStringAsync(url).Result;
            try
            {
                Doctor doc = JsonConvert.DeserializeObject<Doctor>(res);
                label.Text = doc.Name;
                gg.Source = ImageSource.FromStream(() => new MemoryStream(doc.Photo));
            }
            catch (Exception e)
            {
                label.Text = "Хуета " + e.Message;
            }
            //A(url);
        }

        async Task<string> Get(string path)
        {
            string doc = null;
            HttpResponseMessage resp = await httpClient.GetAsync(path);
            doc = await resp.Content.ReadAsStringAsync();
            return doc;
        }

        async void A(string url)
        {
            label.Text = await Get(url);            
        }
    }
}
