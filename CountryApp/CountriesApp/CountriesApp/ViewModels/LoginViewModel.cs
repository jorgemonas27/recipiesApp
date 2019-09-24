using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Validators;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
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
                return new RelayCommand(LoginFirebase);
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(LogoutFirebase);
            }
        }
        
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

        public string AppSettingUser
        {
            get
            {
                return UserSettings.Username;
            }
        }

        public string AppSettingPassword
        {
            get
            {
                return UserSettings.Password;
            }
        }

        private Login login;
        private NavigationService navigation;
        
        #endregion

        #region Ctor
        public LoginViewModel()
        {
            this.login = new Login();
            IsEnabled = true;
            IsRunning = false;
            navigation = new NavigationService();
        }
        #endregion


        #region Methods

        private void SetupEnvironment()
        {
            var state = App.LoadCountry.LoadCountries<State>();
            MainViewModel.GetInstace().AfricaView = new AfricaViewModel(state);
            MainViewModel.GetInstace().AmericasView = new AmericasViewModel(state);
            MainViewModel.GetInstace().AsiaView = new AsiaViewModel(state);
            MainViewModel.GetInstace().EuropeView = new EuropeViewModel(state);
            MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel(state);
        }

        private async void Login()
        {
            IsEnabled = false;
            IsRunning = true;
            if (!App.validate.ValidateCredentials(Email, Password).IsValid)
            {
                IsEnabled = true;
                IsRunning = false;
                App.message.ShowMessage(Resources.Resources.Error, App.validate.ValidateCredentials(Email, Password).Message);
                return;
            }

            var response = await login.LoginUser(Email, Password);
            if (!response)
            {
                IsEnabled = true;
                IsRunning = false;
                App.message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed);
                Password = string.Empty;
                return;
            }
            SaveUserSettings();
            SetupEnvironment();
            navigation.NavigatePage(Resources.Resources.Country);
            IsEnabled = true;
            IsRunning = false;
        }

        private void SaveUserSettings()
        {
            UserSettings.Username = this.Email;
            UserSettings.Password = this.Password;
        }

        private void LogoutFirebase()
        {
            if (login.LogoutUser())
            {
                this.IsRunning = true;
                this.IsEnabled = false;
                ClearCacheInformation();
                navigation.NavigatePage(Resources.Resources.Login);
                this.IsRunning = false;
                this.IsEnabled = true;
            }
        }

        private void DummyLogout()
        {
            this.IsRunning = true;
            this.IsEnabled = false;
            ClearCacheInformation();
            navigation.NavigatePage(Resources.Resources.Login);
            this.IsRunning = false;
            this.IsEnabled = true;
        }

        private void ClearCacheInformation()
        {
            UserSettings.ClearAllData();
            Email = UserSettings.Username;
            Password = UserSettings.Password;
        }

        private async void LoginFirebase()
        {
            var connected = App.connection.CheckConnection();
           
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Login();
                    break;
                case Device.Android:
                    IsEnabled = false;
                    IsRunning = true;
                    if (!connected.IsValid)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        App.message.ShowMessage(Resources.Resources.Error, connected.Message);
                        return;
                    }
                    if (!App.validate.ValidateCredentials(Email, Password).IsValid)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        App.message.ShowMessage(Resources.Resources.Error, App.validate.ValidateCredentials(Email, Password).Message);
                        return;
                    }
                    var response = await login.SignInFirebase(Email, Password);
                    if (!response)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        App.message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed, Resources.Resources.OkMessage);
                        Password = string.Empty;
                        return;
                    }
                    SaveUserSettings();
                    SetupEnvironment();
                    navigation.NavigatePage(Resources.Resources.Country);
                    break;
            }
        }

        #endregion
    }
}
