using CountriesApp.Services;
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

        private Login login;

        private string email = "jorgehmg17@gmail.com";

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                SetValue(ref email, value);
            }
        }

        private string password = "1234";

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

        #region Ctor
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            login = new Login();
            IsEnabled = true;
        }
        #endregion


        #region Methods
        private async void Login()
        {
            if (await login.LoginUser(Email, Password, IsRunning, IsEnabled))
            {
                await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
            }
            //Email = string.Empty;
            //Password = string.Empty;
        }
        #endregion
    }
}
