using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalCabinet : ContentPage
	{
		public PersonalCabinet ()
		{
			InitializeComponent ();
            name.Text = App.CurrentUser?.Profiles[0]?.Name ?? "Не опознано";
            phone.Text = App.CurrentUser?.Phone.ToString() ?? "Не опознано";
            email.Text = App.CurrentUser?.AuthEmail ?? "Не опознано";

            visitsList.ItemsSource = App.CurrentUser?.Visits;
            commentsList.ItemsSource = App.CurrentUser?.Comments;
		}

        private void ShowVisits(object sender, EventArgs e)
        {
            visitsList.IsVisible = !visitsList.IsVisible;
            if (showVisits.Text == "Показать")
                showVisits.Text = "Скрыть";
            else showVisits.Text = "Показать";
        }

        private void ShowComments(object sender, EventArgs e)
        {
            commentsList.IsVisible = !commentsList.IsVisible;
            if (showComments.Text == "Показать")
                showComments.Text = "Скрыть";
            else showComments.Text = "Показать";
        }
    }
}