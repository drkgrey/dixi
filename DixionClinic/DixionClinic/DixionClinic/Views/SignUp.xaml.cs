using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DixionClinic
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        bool isValidEmail = false;
        bool isValidPass = false;

        IFirebaseAuthenticator firebaseAuthenticator;

        public SignUp (IFirebaseAuthenticator authenticator)
		{
			InitializeComponent ();

            firebaseAuthenticator = authenticator;

            UserEmail.TextChanged += UserEmail_TextChanged;
            UserPass.TextChanged += UserPass_TextChanged;
            ConfirmPass.Completed += ConfirmPass_Completed;
            SignUpButton.Clicked += SignUpButton_Clicked;
		}

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            if (isValidPass && isValidEmail &&
                !String.IsNullOrWhiteSpace(Phone.Text)
                && !String.IsNullOrWhiteSpace(UserName.Text)
                && !String.IsNullOrWhiteSpace(UserSecondName.Text))
            {
                firebaseAuthenticator.UserSignUp(UserEmail.Text, UserPass.Text, UserName.Text, UserSecondName.Text, UserThirdName.Text);
                App.Sender.SignUser($"{UserName.Text} {UserSecondName.Text} {UserThirdName.Text}",
                    UserEmail.Text, int.Parse(Phone.Text), App.DeviceToken);
                DisplayAlert("Успешно", "Регистрация успешно завершена. Теперь вы можете войти в приложеие", "ОК");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Ошибка", "Вы должны заполнить все поля, чтобы зарегистрироваться в приложении", "OK");
            }
        }

        private void ConfirmPass_Completed(object sender, EventArgs e)
        {
            ErrorMessagePass.IsVisible = !(ConfirmPass.Text == UserPass.Text);
            isValidPass = !ErrorMessagePass.IsVisible;
        }

        private void UserPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShortPass.IsVisible = UserPass.Text.Length < 8;
            isValidPass = !ShortPass.IsVisible;
        }

        private void UserEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex(emailRegex, RegexOptions.IgnoreCase);
            if (regex.IsMatch(UserEmail.Text))
            {
                //Сделать запрос на существование пользователя с таким мылом
                UserEmail.TextColor = Color.Green;
                //Сделать метку, что все хорошо
                isValidEmail = true;
                ErrorMessageWrongEmail.IsVisible = false;
            }
            else
            {
                isValidEmail = false;
                ErrorMessageWrongEmail.IsVisible = true;
            }
        }
    }
}