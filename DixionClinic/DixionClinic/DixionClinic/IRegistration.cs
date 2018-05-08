using Xamarin.Forms;

namespace DixionClinic
{
    interface IRegistration
    {
        string Login { get; set; }
        string Password { get; set; }
        bool IsVisibleValidDataLabel { set; }
        Page Page { get; }
    }
}
