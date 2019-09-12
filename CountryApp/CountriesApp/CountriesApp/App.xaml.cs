using CountriesApp.Services;
using CountriesApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CountriesApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public string AuthToken { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            if (string.IsNullOrEmpty(UserSettings.Username) && string.IsNullOrEmpty(UserSettings.Password))
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("#084c9e")
                };
            }
            else
            {
                MainPage = new NavigationPage(new CountriesPage())
                {
                    BarBackgroundColor = Color.FromHex("#084c9e")
                };
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
