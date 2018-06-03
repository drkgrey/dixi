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
    public partial class Directions : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Directions()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Направление 1",
                "Направление 2",
                "Направление 3",
                "Направление 4",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5",
                "Направление 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (e.Item.ToString() == "Направление 1")
            {
                Navigation.PushAsync(new Departments());
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
