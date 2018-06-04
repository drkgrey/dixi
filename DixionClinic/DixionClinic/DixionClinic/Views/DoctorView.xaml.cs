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
        HttpClient httpClient = new HttpClient();

        public DoctorView(int id,int depId)
		{
			InitializeComponent ();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            DownloadDoctor(id);
            DownloadFeedBack(id);
            sign.Clicked += (s, e) => { Navigation.PushAsync(new Reception(depId, id)); };
        }

        void DownloadFeedBack(int id)
        {
            var url = App.ConnectionString + $"api/CommentsSpec/{id}";
            var res = httpClient.GetStringAsync(url).Result;
            var comments = JsonConvert.DeserializeObject<Comment[]>(res);

            //Возможно нужно будет скачивать пациентов и привязывать их к комментариям

            commentsList.ItemsSource = comments;
        }

        void DownloadDoctor(int id)
        {
            var url = App.ConnectionString + $"api/Doctor/{id}";
            string res = httpClient.GetStringAsync(url).Result;
            Doctor doc = JsonConvert.DeserializeObject<Doctor>(res);
            name.Text = doc.Name;
            cat.Text = doc.Category;
            info.Text = doc.Info;
            photo.Source = ImageSource.FromStream(() => new MemoryStream(doc.Photo));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            info.IsVisible = !info.IsVisible;
            if (show.Text == "Показать") show.Text = "Скрыть";
            else show.Text = "Показать";
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            commentsList.IsVisible = !commentsList.IsVisible;
            if (showFeedBack.Text == "Показать") showFeedBack.Text = "Скрыть";
            else showFeedBack.Text = "Показать";
        }
    }
}