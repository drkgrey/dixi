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
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(
                new HomePage()
                {
                    Title = "Новости и акции",
                });
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageMenuItem;
            if (item == null)
                return;
            if (item.Id == 0)
                Detail = new NavigationPage(new HomePage()/*Специалисты*/);
            else if (item.Id == 1)
                Detail = new NavigationPage(new HomePage()/*Новости и акции*/);
            else if (item.Id == 2)
                Detail = new NavigationPage(new HomePage()/*Запись на прием*/);
            else if (item.Id == 3)
                Detail = new NavigationPage(new HomePage()/*Прейскурант*/);
            else if (item.Id == 4)
                Detail = new NavigationPage(new HomePage()/*Наши контакты*/);
            else if (item.Id == 5)
                Detail = new NavigationPage(new HomePage()/*Личный кабинет*/);
            else if (item.Id == 6)
                Detail = new NavigationPage(new HomePage()/*Отзывы*/);

            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}