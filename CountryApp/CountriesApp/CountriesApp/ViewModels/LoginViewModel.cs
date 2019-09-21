using CountriesApp.Services;
using CountriesApp.Validators;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
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

        private Login login;

        private MessageManager message;

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

        private ValidateLoginFields validator;
        private NavigationService navigation;
        private ConnectionChecker connection;

        #endregion

        #region Ctor
        public LoginViewModel()
        {
            login = new Login();
            IsEnabled = true;
            IsRunning = false;
            message = new MessageManager();
            validator = new ValidateLoginFields();
            navigation = new NavigationService();
            connection = new ConnectionChecker();
        }
        #endregion


        #region Methods
        private async void Login()
        {
            IsEnabled = false;
            IsRunning = true;
            if (!validator.ValidateCredentials(Email, Password).IsValid)
            {
                IsEnabled = true;
                IsRunning = false;
                message.ShowMessage(Resources.Resources.Error, validator.ValidateCredentials(Email, Password).Message);
                return;
            }

            var response = await login.LoginUser(Email, Password);
            if (!response)
            {
                IsEnabled = true;
                IsRunning = false;
                message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed);
                Password = string.Empty;
                return;
            }
            SaveUserSettings();
            var list = App.LoadCountry.LoadCountries();
            MainViewModel.GetInstace().AfricaView = new AfricaViewModel(list);
            MainViewModel.GetInstace().AmericasView = new AmericasViewModel(list);
            MainViewModel.GetInstace().AsiaView = new AsiaViewModel(list);
            MainViewModel.GetInstace().EuropeView = new EuropeViewModel(list);
            MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel(list);
            navigation.NavigatePage(Resources.Resources.Country);
            IsEnabled = true;
            IsRunning = false;
        }

        private void InitializeCountriesModels()
        {
            //MainViewModel.GetInstace().CountryView = new CountryViewModel(App.LoadCountry, App.apiService);
            //MainViewModel.GetInstace().CountryView.GetCountries();
            //MainViewModel.GetInstace().AfricaView = new AfricaViewModel();
            //MainViewModel.GetInstace().AsiaView = new AsiaViewModel();
            //MainViewModel.GetInstace().EuropeView = new EuropeViewModel();
            //MainViewModel.GetInstace().AmericasView = new AmericasViewModel();
            //MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel();
        }

        private void SaveUserSettings()
        {
            UserSettings.Username = this.Email;
            UserSettings.Password = this.Password;
        }

        private async void LogoutFirebase()
        {
            var connected = await connection.CheckConnection();
            if (!connected.IsValid)
            {
                message.ShowMessage(Resources.Resources.Error, connected.Message);
                return;
            }
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
            var connected = await connection.CheckConnection();
           
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
                        message.ShowMessage(Resources.Resources.Error, connected.Message);
                        return;
                    }
                    if (!validator.ValidateCredentials(Email, Password).IsValid)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        message.ShowMessage(Resources.Resources.Error, validator.ValidateCredentials(Email, Password).Message);
                        return;
                    }
                    var response = await login.SignInFirebase(Email, Password);
                    if (!response)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed, Resources.Resources.OkMessage);
                        Password = string.Empty;
                        return;
                    }
                    SaveUserSettings();
                    var list = App.LoadCountry.LoadCountries();
                    MainViewModel.GetInstace().AfricaView = new AfricaViewModel(list);
                    MainViewModel.GetInstace().AmericasView = new AmericasViewModel(list);
                    MainViewModel.GetInstace().AsiaView = new AsiaViewModel(list);
                    MainViewModel.GetInstace().EuropeView = new EuropeViewModel(list);
                    MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel(list);
                    InitializeCountriesModels();
                    navigation.NavigatePage(Resources.Resources.Country);
                    break;
            }
        }

        #endregion
    }
}
