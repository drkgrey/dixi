using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DixionClinic
{
    public partial class App : Application
    {
        //public static string Token { get; set; }
        public static IFirebaseAuthenticator FirebaseAuth { get; set; }
        public static string DeviceToken { get; set; }
        public static string ConnectionString { get; } = "http://arkonlab.website/";

        static public Patient CurrentUser { get; private set; }

        public static SendRegistrationDataToServer Sender = new SendRegistrationDataToServer();

        public App()
        {
            //Сделан для исправления ошибки соответствия .xaml и .xaml.cs
        }

        static public async Task GetPatient(string email)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var url = ConnectionString + $"api/Patient?email={email}";
            string res = client.GetStringAsync(url).Result;
            CurrentUser = JsonConvert.DeserializeObject<Patient>(res);

            return;
        }

        public App(IFirebaseAuthenticator authenticator)
        {
            InitializeComponent();
            DeviceToken = authenticator.GetDeviceToken();
            FirebaseAuth = authenticator;
            MainPage = new NavigationPage(new Registration(authenticator));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
