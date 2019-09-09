using CountriesApp.Services;
using CountriesApp.Validators;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CountriesApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {


        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(Logout);
            }
        }
        
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
            login = new Login();
            IsEnabled = true;
        }
        #endregion


        #region Methods
        private async void Login()
        {
            IsEnabled = false;
            IsRunning = true;
            if (await login.LoginUser(Email, Password))
            {
                await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
            }
        }

        private async void Logout()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion
    }
}
