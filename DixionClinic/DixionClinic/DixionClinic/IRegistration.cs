using Xamarin.Forms;

namespace DixionClinic
{
    interface IRegistration
    {
        string Login { get; }
        string Password { get; }
        bool IsVisibleValidDataLabel { set; }
        Page Page { get; }
    }
}
