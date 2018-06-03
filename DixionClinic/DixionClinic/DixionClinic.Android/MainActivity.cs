using System;
using Android.Gms.Common;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Nfc;
using System.Threading.Tasks;

namespace DixionClinic.Droid
{
    [Activity(Label = "DixionClinic", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug("Key: {0} Value: {1}", key, value);
                }
            }

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            

            var options = new FirebaseOptions.Builder()
                    .SetApplicationId("1:986776431713:android:4fab5679aa1289b7")
                    .SetApiKey("AIzaSyDLMCTWPYA-BwFQBrm26t7N8rxCDFqSnd4")
                    .Build();

            try
            {
                FirebaseApp.InitializeApp(this, options);
            }
            catch
            {
                FirebaseApp.InitializeApp(this, options, "1");
            }

            //var app = FirebaseApp.Instance;

            LoadApplication(new App(new FirebaseAutenticator()));

        }
    }
}

