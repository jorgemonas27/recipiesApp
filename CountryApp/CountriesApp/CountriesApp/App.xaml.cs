using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Validators;
using CountriesApp.ViewModels;
using CountriesApp.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CountriesApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static ConnectionChecker connection;
        public static MessageManager message;
        public static ILoadCountry LoadCountry;
        public static IService apiService;
        public static ValidateLoginFields validate;
        public static string serializePath => FileAccessHelper.GetLocalFilePath("countries.txt");

        public App()
        {
            InitializeComponent();
            validate = new ValidateLoginFields();
            connection = new ConnectionChecker();
            message = new MessageManager();
            apiService = new ApiService();
            LoadCountry = new LoadCountry(new ApiService(), new SerializerHelper());
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
                SetupEnvironment();
                MainPage = new NavigationPage(new CountriesPage())
                {
                    BarBackgroundColor = Color.FromHex("#084c9e"),
                    BarTextColor = Color.White
                };
            }
        }

        private void SetupEnvironment()
        {
            var state = LoadCountry.LoadCountries<State>();
            MainViewModel.GetInstace().AfricaView = new AfricaViewModel(state);
            MainViewModel.GetInstace().AmericasView = new AmericasViewModel(state);
            MainViewModel.GetInstace().AsiaView = new AsiaViewModel(state);
            MainViewModel.GetInstace().EuropeView = new EuropeViewModel(state);
            MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel(state);
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
