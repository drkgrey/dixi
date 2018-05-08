using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DixionClinic
{
    class RegistrationViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand ToHomePage { get; private set; }
        public ICommand ToForgetPassPage { get; private set; }
        public ICommand ToSignUpPage { get; private set; }

        IRegistration regInfo;
        IFirebaseAuthenticator firebaseAuthenticator;
        bool IsValidUser = false;

        public RegistrationViewModel(IRegistration reg, IFirebaseAuthenticator authenticator)
        {
            regInfo = reg;
            firebaseAuthenticator = authenticator;
            ToHomePage = new Command(GoToHomePage);
            ToForgetPassPage = new Command(GoToForgetPassPage);
            ToSignUpPage = new Command(GoToSignUpPage);
        }

        async void GoToHomePage()
        {
            var token = "1";
            try
            {
                token = await firebaseAuthenticator.LoginWithEmailPassword(regInfo.Login, regInfo.Password);
                IsValidUser = true;
            }
            catch
            {
                regInfo.IsVisibleValidDataLabel = true;
            }
            if (token != "1")
            {
                regInfo.IsVisibleValidDataLabel = false;
                Navigation.InsertPageBefore(new MainPage(), regInfo.Page);
                await Navigation.PopAsync();
            }
        }

        void GoToForgetPassPage()
        {

        }

        void GoToSignUpPage()
        {

        }
    }
}
