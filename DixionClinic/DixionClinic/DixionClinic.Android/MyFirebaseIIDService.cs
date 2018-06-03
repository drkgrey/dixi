using System;
using Android.App;
using Firebase.Iid;
using Android.Util;
using System.Net;
using Firebase.Auth;
using Newtonsoft.Json;
using System.IO;

namespace DixionClinic.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }

        async void SendRegistrationToServer(string token)
        {
            // сюда пост запрос с отправкой токена и мыла
            var email = FirebaseAuth.Instance.CurrentUser.Email;
            var request = WebRequest.Create("https://arkonlab.website/api/Auths") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            string data = JsonConvert.SerializeObject(new { Token = token, Email = email });
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream)) { }
            }
            response.Close();
        }
    }
}