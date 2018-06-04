using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Iid;
using Newtonsoft.Json;

namespace DixionClinic.Droid
{
    class FirebaseAutenticator : IFirebaseAuthenticator
    {
        Random rnd = new Random();

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.
                            SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetTokenAsync(false);

            return token.Token;
        }

        public async void UserSignUp(string email, string pass, string name, string sName, string tName)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, pass);
            var userProfileChangeRequest = new UserProfileChangeRequest.Builder()
                .SetDisplayName($"{name} {sName} {tName}")
                .Build();
            user.User.UpdateProfile(userProfileChangeRequest);
        }

        public string GetDeviceToken()
        {
            return FirebaseInstanceId.Instance.Token;
        }

        public async void SendRegistrationToServer(string token)
        {
            //Пока не знаю, нужен ли этот метод

            //var email = FirebaseAuth.Instance.CurrentUser.Email;
            //var request = WebRequest.Create("https://arkonlab.website/api/Auths") as HttpWebRequest;
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //string data = JsonConvert.SerializeObject(new { Token = token, Email = email });
            //byte[] byteArray = Encoding.UTF8.GetBytes(data);
            //request.ContentLength = byteArray.Length;
            //using (Stream dataStream = request.GetRequestStream())
            //{
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //}
            //WebResponse response = await request.GetResponseAsync();
            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (StreamReader reader = new StreamReader(stream)) { }
            //}
            //response.Close();
        }

        void CreateUser()
        {
            //FIXME!
        }
    }
}