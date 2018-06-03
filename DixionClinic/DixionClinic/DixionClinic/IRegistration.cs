﻿using Xamarin.Forms;

namespace DixionClinic
{
    interface IRegistration
    {
        string Login { get; }
        string Password { get; }
        bool IsVisibleValidDataLabel { set; }
        bool IndicatorIsVisible { set; }
        bool BttnSignIsVisible { set; }
        Page Page { get; }
    }
}
