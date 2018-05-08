using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registration : ContentPage, IRegistration
	{
        public string Login { get => Email.Text; set => Email.Text = value; }
        public string Password { get => Pass.Text; set => Pass.Text = value; }
        public bool IsVisibleValidDataLabel { set => IsValidData.IsVisible = value; }
        public Page Page => this;

        public Registration (IFirebaseAuthenticator authenticator)
		{
			InitializeComponent ();
            BindingContext = new RegistrationViewModel(this, authenticator) { Navigation = this.Navigation };
        }
    }
}