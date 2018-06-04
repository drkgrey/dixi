using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DixionClinic
{
    public partial class App : Application
    {
        //public static string Token { get; set; }
        public IFirebaseAuthenticator FirebaseAuth { get; set; }
        public static string DeviceToken { get; set; }
        public static string ConnectionString { get; } = "http://arkonlab.website/";

        public static SendRegistrationDataToServer Sender = new SendRegistrationDataToServer();

        public App()
        {
            //Сделан для исправления ошибки соответствия .xaml и .xaml.cs
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
