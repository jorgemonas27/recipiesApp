using CountriesApp.Services;
using CountriesApp.Validators;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private MessageManager message;

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                UserSettings.Username = value;
                email = UserSettings.Username;
                SetValue(ref email, value);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                UserSettings.Password = value;
                password = UserSettings.Password;
                SetValue(ref password, value);
            }
        }

        private bool isrunning;
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
            IsRunning = false;
            message = new MessageManager();
             
        }
        #endregion


        #region Methods
        private async void Login()
        {
            IsEnabled = false;
            IsRunning = true;
            if (await login.LoginUser(Email, Password))
            {
                IsEnabled = true;
                IsRunning = false;
               
                await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
            }
            else
            {
                IsEnabled = true;
                IsRunning = false;
            }
        }

        private async void Logout()
        {
            UserSettings.ClearAllData();
            Email = UserSettings.Username;
            Password = UserSettings.Password;
            await App.Current.MainPage.Navigation.PopToRootAsync();
            this.IsRunning = false;
            this.IsEnabled = true;
        }

        private async void LoginFirebase()
        {
            IsRunning = true;
            var token = await login.LoginFirebaseService(Email, Password);
            if (!string.IsNullOrEmpty(token))
            {
                await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
            }
            IsRunning = false;
        }

        #endregion
    }
}
