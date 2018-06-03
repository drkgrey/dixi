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
        public string Login { get => Email.Text; }
        public string Password { get => Pass.Text; }
        public bool IsVisibleValidDataLabel { set => IsValidData.IsVisible = value; }
        public Page Page => this;
        public bool IndicatorIsVisible { set => loadIndicator.IsVisible = value; }
        public bool BttnSignIsVisible { set => signBttn.IsVisible = value; }

        public Registration (IFirebaseAuthenticator authenticator)
		{
			InitializeComponent ();
            //отладка
            //delThis.Text = authenticator.GetDeviceToken();
            //конец отладки
            BindingContext = new RegistrationViewModel(this, authenticator) { Navigation = this.Navigation };
        }
    }
}