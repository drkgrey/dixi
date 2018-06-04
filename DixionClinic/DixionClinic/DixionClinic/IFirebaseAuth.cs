using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DixionClinic
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        string GetDeviceToken();
        void SendRegistrationToServer(string token);
        void UserSignUp(string email, string pass, string name, string sName, string tName);
    }
}
