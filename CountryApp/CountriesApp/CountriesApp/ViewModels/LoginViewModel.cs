using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

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
        
        private async void LogoutFirebase()
        {
            if (login.LogoutUser())
            {
                ClearCacheInformation();
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage(), true);
                this.IsRunning = false;
                this.IsEnabled = true;
            }
        }

        private async void DummyLogout()
        {
            ClearCacheInformation();
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage(), true);
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
            IsRunning = true;
            if (await login.SignInFirebase(Email, Password))
            {
                MainViewModel.GetInstace().CountryView = new CountryViewModel();
                await App.Current.MainPage.Navigation.PushAsync(new CountriesPage(), true);
            }
            else
            {
                IsRunning = false;
                message.ShowMessage(Resources.Resources.Error, Resources.Resources.AuthenticationFailed, Resources.Resources.OkMessage);
                return;
            }
            IsRunning = false;
        }

        #endregion
    }
}
