﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        
        class Auth
        {
            public int Id { get; set; }
            public string Token { get; set; }
            public string Email { get; set; }
        }

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
            Auth auth = new Auth();
            var token = "";
            try
            {
                token = await firebaseAuthenticator.LoginWithEmailPassword(regInfo.Login, regInfo.Password);
                //Использовать страницу с индикатором загрузки
                regInfo.IndicatorIsVisible = true;
                regInfo.Disable();
                //                
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var url = App.ConnectionString + $"api/Auths?email={regInfo.Login}";
                string res = await httpClient.GetStringAsync(url);
                auth = JsonConvert.DeserializeObject<Auth>(res);
                if (auth == null)
                    App.Sender.SignAuth(regInfo.Login, firebaseAuthenticator.GetDeviceToken());
                else if (auth.Token != App.DeviceToken)
                {
                    //Тут нужен PUT запрос !!!!
                }
                //await App.GetPatient(regInfo.Login);
            }
            catch
            {
                regInfo.IsVisibleValidDataLabel = true;
            }
            if (token != "")
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
            Navigation.PushAsync(new SignUp(firebaseAuthenticator));
        }
    }
}
