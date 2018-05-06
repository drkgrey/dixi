using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestFirebaseAuth
{
	public partial class App : Application
	{
        public IFirebaseAuthenticator FirebaseAuthenticator { get; set; }

        public App (IFirebaseAuthenticator firebaseAuthenticator)
		{
			InitializeComponent();
            FirebaseAuthenticator = firebaseAuthenticator;
			MainPage = new TestFirebaseAuth.MainPage(FirebaseAuthenticator);
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
