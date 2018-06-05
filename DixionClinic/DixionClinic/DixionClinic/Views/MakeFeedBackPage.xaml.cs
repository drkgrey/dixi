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
	public partial class MakeFeedBackPage : ContentPage
	{
        static HttpClient client = new HttpClient();

        int ID;

        public MakeFeedBackPage (int id)
		{
			InitializeComponent ();
            ID = id;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            if (id != 0) typeOfFeedBack.Text = "Отзыв о враче";
            else typeOfFeedBack.Text = "Отзыв о клинике";

            sendFeedBack.Clicked += SendFeedBack_Clicked;
        }

        private async void SendFeedBack_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(feedBack.Text))
            {
                await DisplayAlert("Ошибка", "Поле \"Отзыв\" пустое. Вы не можете отправить пустой отзыв", "OK");
                return;
            }
            string json = JsonConvert.SerializeObject(new Comment {
                Text = feedBack.Text,
                PatientId = App.CurrentUser?.Id ?? 0,
                SpecialistID = ID
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var urlToPost = new Uri("http://arkonlab.website/api/Comments");
            var result = client.PostAsync(urlToPost, content).Result;
            var r = await result.Content.ReadAsStringAsync();
        }
    }
}