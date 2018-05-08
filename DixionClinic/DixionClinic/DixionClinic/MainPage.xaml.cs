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
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageMenuItem;
            if (item.Id == 0)
                Detail = new NavigationPage(/*Специалисты*/);
            else if (item.Id == 1)
                Detail = new NavigationPage(/*Новости и акции*/);
            else if (item.Id == 2)
                Detail = new NavigationPage(/*Запись на прием*/);
            else if (item.Id == 3)
                Detail = new NavigationPage(/*Прейскурант*/);
            else if (item.Id == 4)
                Detail = new NavigationPage(/*Наши контакты*/);
            else if (item.Id == 5)
                Detail = new NavigationPage(/*Личный кабинет*/);
            else if (item.Id == 6)
                Detail = new NavigationPage(/*Отзывы*/);
            //if (item == null)
            //    return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}