using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestFirebaseAuth
{
	public partial class MainPage : ContentPage
	{
        IFirebaseAuthenticator authenticator;
		public MainPage(IFirebaseAuthenticator firebaseAuthenticator)
		{
			InitializeComponent();
            authenticator = firebaseAuthenticator;
            Auth.Clicked += Auth_Click;
            Out.Clicked += Out_Click;
		}
        
        private async void Auth_Click(object sender, EventArgs e)
        {
            string token = "No token :(";            
            try
            {
                token = await authenticator.LoginWithEmailPassword("pass1@test.ru", "22222222");
            }
            catch (AggregateException x)
            {
                TestLabel.Text = x.Message + " AggregateEx";
            }
            catch (Exception x)
            {
                TestLabel.Text = x.Message; 
            }
            var a = await authenticator.IsCurrent();
            Res.Text = a.ToString();
        }

        private async void Out_Click(object sender, EventArgs e)
        {
            var a = await authenticator.IsCurrent();
            TestLabel.Text = a.ToString();
            try
            {
                authenticator.LogOut();
            }
            catch (AggregateException x)
            {
                TestLabel.Text = x.Message + " AggregateEx";
            }
            catch (Exception x)
            {
                TestLabel.Text = x.Message;
            }
            a = await authenticator.IsCurrent();
            Res.Text = a.ToString();
        }
    }
}
