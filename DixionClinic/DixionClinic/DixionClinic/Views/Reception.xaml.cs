using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reception : ContentPage
    {
        HttpClient httpClient = new HttpClient();

        TimeSpan start = new TimeSpan(9, 0, 0);
        readonly TimeSpan final = new TimeSpan(18, 00, 00);
        List<TimeSpan> timeSpans = new List<TimeSpan>();
        List<TimeSpan> buisyTime = new List<TimeSpan>();
        Department[] deps;
        Doctor[] doc;
        Visit[] visits;

        public Reception()
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            GetDep();
            SetTimeArray();
            depPicker.ItemsSource = deps;
        }

        public Reception(int depId, int docId)
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            GetDep();
            SetTimeArray();

            var dep = deps.Where(e => e.Id == depId).ToArray();
            depPicker.ItemsSource = dep;
            depPicker.SelectedItem = dep[0];

            var url = App.ConnectionString + $"api/Departament?name={(depPicker.SelectedItem as Department).Name}";
            string res = httpClient.GetStringAsync(url).Result;
            doc = JsonConvert.DeserializeObject<Doctor[]>(res);
            doctorPicker.ItemsSource = doc;
            doctorPicker.SelectedItem = doc.Where(e => e.Id == docId).ToArray()[0];

            datePicker.IsEnabled = true;
            timePicker.IsEnabled = true;
            depPicker.IsEnabled = false;
            doctorPicker.IsEnabled = false;
        }

        void SetTimeArray()
        {
            do
            {
                timeSpans.Add(start);
                start += TimeSpan.FromMinutes(15);
            }
            while (timeSpans[timeSpans.Count - 1].Hours < final.Hours);
            timeSpans.RemoveAt(timeSpans.Count - 1);

            datePicker.MinimumDate = DateTime.Today;
        }

        void GetVisits()
        {
            var urlVis = App.ConnectionString + "api/Visit";
            string resVis = httpClient.GetStringAsync(urlVis).Result;
            visits = JsonConvert.DeserializeObject<Visit[]>(resVis);
        }

        void GetDep()
        {
            var urlDep = App.ConnectionString + "api/Departament";
            string resDep = httpClient.GetStringAsync(urlDep).Result;
            deps = JsonConvert.DeserializeObject<Department[]>(resDep);
            GetVisits();
        }

        void SelectDateAndTime(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                DisplayAlert("Внимание!", "Воскресенье является выходным днем. Доступных записей нет", "OK");
                timePicker.ItemsSource = null;
                return;
            }

            var currentSpec = (doctorPicker.SelectedItem as Doctor).Specialists.Where(
              a => a.DepartamentId == (depPicker.SelectedItem as Department).Id) as Specialist;
            var arrayOfBuisyTime = visits.Where(a => a.SpecialistId == currentSpec.Id && a.Day == datePicker.Date).ToArray();
            if (arrayOfBuisyTime != null)
            {
                foreach (var visit in arrayOfBuisyTime)
                {
                    buisyTime.Add(visit.Hour);
                }
            }
            timePicker.ItemsSource = timeSpans.Except(buisyTime).ToArray();
        }

        private void DepPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var url = App.ConnectionString + $"api/Departament?name={(depPicker.SelectedItem as Department).Name}";
            string res = httpClient.GetStringAsync(url).Result;
            doc = JsonConvert.DeserializeObject<Doctor[]>(res);
            doctorPicker.ItemsSource = doc;
            doctorPicker.IsEnabled = true;
        }

        private void DoctorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            datePicker.IsEnabled = true;
            SelectDateAndTime(datePicker.Date);
            timePicker.IsEnabled = true;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = e.NewDate;
            SelectDateAndTime(date);
        }

        private async void Sign_Clicked(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new System.Net.NetworkCredential("dixiontestmail@gmail.com", "dixi12345678"),
                EnableSsl = true
            };
            string to = "uselessacc63@gmail.com";
            string from = "dixiontestmail@gmail.com";
            string subject = "Test SMTP Client.";
            string body = @"Now you see me... Now you don't...";
            MailMessage message = new MailMessage(from, to, subject, body);
            await smtpClient.SendMailAsync(message);
            await DisplayAlert("Успешно", "Вы отправили заявку на прием. В ближайшее время с вами свяжутся.", "OK");
            await Navigation.PopAsync();
        }

        private void TimePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            sign.IsEnabled = true;
        }
    }
}