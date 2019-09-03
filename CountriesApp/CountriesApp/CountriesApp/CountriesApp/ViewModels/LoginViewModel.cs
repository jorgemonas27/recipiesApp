using CountriesApp.Validators;
using CountriesApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountriesApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands
        public Command LoginCommand { get; set; }

        #endregion


        #region Props
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                SetValue(ref email, value);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                SetValue(ref password, value);
            }
        }

        private bool isrunning = false;

        public bool IsRunning
        {
            get { return isrunning; }
            set
            {
                isrunning = value;
                SetValue(ref isrunning, value);
            }
        }

        private bool isenabled = true;

        public bool IsEnabled
        {
            get { return isenabled; }
            set
            {
                isenabled = value;
                SetValue(ref isenabled, value);
            }
        }

        #endregion

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            Email = "jorgehmg17@gmail.com";
            Password = "1234";
            IsEnabled = true;
        }

        
        private async void Login()
        {

            if (ValidateLoginFields.IsEmptyField(Email, Password))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "The email or password is empty",
                    "Ok");
                return;
            }

            if (!ValidateLoginFields.IsValidEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "The email is not a valid email please check it",
                "Ok");
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            await Task.Delay(3000);


            if (Email != "jorgehmg17@gmail.com" || Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                this.Password = string.Empty;
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "The credentials are not valid please check the email and password",
                    "Ok");
                return;
            }

            IsRunning = false;
            IsEnabled = true;

            Email = string.Empty;
            Password = string.Empty;

            MainViewModel.GetInstace().CountryView = new CountryViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
        }
    }
}
