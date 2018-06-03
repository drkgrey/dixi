using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Specialists : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Specialists()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Специалист 1",
                "Специалист 2",
                "Специалист 3",
                "Специалист 4",
                "Специалист 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            if (e.Item.ToString() == "Специалист 1")
                await Navigation.PushAsync(new MainPage());

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
