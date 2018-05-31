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
    public partial class Reception : ContentPage
    {
        HttpClient httpClient = new HttpClient();

        TimeSpan start = new TimeSpan(9, 0, 0);
        readonly TimeSpan final = new TimeSpan(18, 00, 00);
        List<TimeSpan> timeSpans = new List<TimeSpan>();
        List<TimeSpan> buisyTime = new List<TimeSpan>();
        Specialist[] specialists;
        Doctor[] doctors;
        Visit[] visits;

        public Reception()
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            GetDocAndVis();
            SetTimeArray();
            doctorPicker.ItemsSource = doctors;
        }

        public Reception(int specId)
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            GetDocAndVis();
            SetTimeArray();

            var spec = specialists.Where(e => e.Id == specId).ToArray();
            specPicker.ItemsSource = spec;
            specPicker.SelectedItem = specialists.Where(e => e.Id == specId).ToArray()[0];
            doctorPicker.ItemsSource = doctors.Where(e => e.Id == spec[0].DoctorId).ToArray();
            doctorPicker.SelectedItem = doctors.Where(e => e.Id == spec[0].DoctorId).ToArray()[0];

            datePicker.IsEnabled = true;
            timePicker.IsEnabled = true;
            specPicker.IsEnabled = false;
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

        void GetDocAndVis()
        {
            var urlDoc = App.ConnectionString + "api/Doctor";
            var urlSpec = App.ConnectionString + "api/Specialist";
            string resDoc = httpClient.GetStringAsync(urlDoc).Result;
            string resSpec = httpClient.GetStringAsync(urlSpec).Result;
            specialists = JsonConvert.DeserializeObject<Specialist[]>(resSpec);
            doctors = JsonConvert.DeserializeObject<Doctor[]>(resDoc);
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
            var currentDoc = specPicker.SelectedItem as Specialist;
            var arrayOfBuisyTime = currentDoc?.Visits?.Where(a => a.Day == datePicker.Date);
            if (arrayOfBuisyTime != null)
            {
                foreach (var visit in arrayOfBuisyTime)
                {
                    buisyTime.Add(visit.Hour);
                }
            }
            timePicker.ItemsSource = timeSpans.Except(buisyTime).ToArray();
        }

        private void SpecPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            datePicker.IsEnabled = true;
            SelectDateAndTime(datePicker.Date);
            timePicker.IsEnabled = true;
        }

        private void DoctorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var doc = doctorPicker.SelectedItem as Doctor;
            specPicker.IsEnabled = true;
            specPicker.ItemsSource = specialists.Where(a => a.DoctorId == doc.Id).ToArray();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = e.NewDate;
            SelectDateAndTime(date);
        }

        private void Sign_Clicked(object sender, EventArgs e)
        {

        }

        private void TimePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            sign.IsEnabled = true;
        }
    }
}