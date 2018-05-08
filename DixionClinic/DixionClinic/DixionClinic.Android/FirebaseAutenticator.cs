using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;

namespace DixionClinic.Droid
{
    class FirebaseAutenticator: IFirebaseAuthenticator 
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.
                            SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetTokenAsync(false);
            return token.Token;
        }
    }
}