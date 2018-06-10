using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DixionClinic
{
    public class SendRegistrationDataToServer
    {
        static HttpClient client = new HttpClient();

        public SendRegistrationDataToServer()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async void SignAuth(string email, string token)
        {
            string json = JsonConvert.SerializeObject(new { Token = token, Email = email });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = new Uri("http://arkonlab.website/api/Auths");
            var result = client.PostAsync(url, content).Result;
            var r = await result.Content.ReadAsStringAsync();
        }

        async void SignPatient(string email, string phone)
        {
            string json = JsonConvert.SerializeObject(new { AuthEmail = email, Phone = phone });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = new Uri("http://arkonlab.website/api/Patient");
            var result = client.PostAsync(url, content).Result;
            var r = await result.Content.ReadAsStringAsync();
        }

        async void SignProfile(string email, string name)
        {
            //GET
            var url = App.ConnectionString + $"api/Patient?email={email}";
            string res = client.GetStringAsync(url).Result;
            var patient = JsonConvert.DeserializeObject<Patient>(res);
            //POST
            string json = JsonConvert.SerializeObject(new Profile { Name = name, PatientId = patient.Id });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var urlToPost = new Uri("http://arkonlab.website/api/Profile");
            var result = client.PostAsync(urlToPost, content).Result;
            var r = await result.Content.ReadAsStringAsync();
        }

        public void SignUser(string fullName, string email, string phone, string token)
        {
            SignAuth(email, token);
            SignPatient(email, phone);
            SignProfile(email, fullName);
        }
    }
}
