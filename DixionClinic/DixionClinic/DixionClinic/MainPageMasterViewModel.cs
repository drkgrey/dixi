using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DixionClinic
{
    class MainPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Специалисты" },
                    new MainPageMenuItem { Id = 1, Title = "Новости и акции" },
                    new MainPageMenuItem { Id = 2, Title = "Запись на прием" },
                    new MainPageMenuItem { Id = 3, Title = "Прейскурант" },
                    new MainPageMenuItem { Id = 4, Title = "Наши контакты" },
                    new MainPageMenuItem { Id = 5, Title = "Личный кабинет" },
                    new MainPageMenuItem { Id = 6, Title = "Отзывы" },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}