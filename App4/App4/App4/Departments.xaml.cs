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
    public partial class Departments : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Departments()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Отделение 1",
                "Отделение 2",
                "Отделение 3",
                "Отделение 4",
                "Отделение 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (e.Item.ToString() == "Отделение 1")
            {
                Navigation.PushAsync(new Specialists());
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
