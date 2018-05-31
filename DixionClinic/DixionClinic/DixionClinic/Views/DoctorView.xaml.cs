using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorView : ContentPage
	{
		public DoctorView(int id,int specId)
		{
			InitializeComponent ();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = App.ConnectionString + $"api/Doctor/{id}";
            string res = httpClient.GetStringAsync(url).Result;
            Doctor doc = JsonConvert.DeserializeObject<Doctor>(res);
            name.Text = doc.Name;
            cat.Text = doc.Category;
            info.Text = doc.Info;
            photo.Source = ImageSource.FromStream(() => new MemoryStream(doc.Photo));

            sign.Clicked += (s, e) => { Navigation.PushAsync(new Reception(specId)); };
        }
	}
}