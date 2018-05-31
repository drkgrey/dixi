using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DixionClinic
{
    public partial class App : Application
    {
        public static string Token { get; set; }
        //IFirebaseAuthenticator FirebaseAuth { get; set; }
        public string DeviceToken {get; set;}
        public static string ConnectionString { get; } = "http://arkonlab.website/";

        public App()
        {
                
        }

        public App(IFirebaseAuthenticator authenticator)
		{
			InitializeComponent();
            DeviceToken = authenticator.GetDeviceToken();
            //FirebaseAuth = authenticator;
			MainPage = new NavigationPage(new Registration(authenticator));
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
