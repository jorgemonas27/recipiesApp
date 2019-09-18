using CountriesApp.Services;
using CountriesApp.ViewModels;
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
        private ConnectionChecker connection;
        private MessageManager message;

        public App()
        {
            InitializeComponent();
            connection = new ConnectionChecker();
            message = new MessageManager();
        }

        protected override void OnStart()
        {
           
            if (string.IsNullOrEmpty(UserSettings.Username) && string.IsNullOrEmpty(UserSettings.Password))
            {
                var loginPage = new LoginPage();
                NavigationPage.SetHasNavigationBar(loginPage, false);
                MainPage = new NavigationPage(loginPage)
                {
                    BarBackgroundColor = Color.FromHex("#084c9e"),
                    BarTextColor = Color.White
                };
            }
            else
            {
                MainViewModel.GetInstace().AfricaView = new AfricaViewModel();
                MainViewModel.GetInstace().AsiaView = new AsiaViewModel();
                MainViewModel.GetInstace().EuropeView = new EuropeViewModel();
                MainViewModel.GetInstace().AmericasView = new AmericasViewModel();
                MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel();

                MainPage = new NavigationPage(new CountriesPage())
                {
                    BarBackgroundColor = Color.FromHex("#084c9e"),
                    BarTextColor = Color.White
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
