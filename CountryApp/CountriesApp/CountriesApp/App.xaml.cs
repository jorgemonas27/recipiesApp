using CountriesApp.Database;
using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.ViewModels;
using CountriesApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CountriesApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public string AuthToken { get; set; }
        public static ConnectionChecker connection;
        public static MessageManager message;
        public static ILoadCountry<Country> LoadCountry;
        public static IService apiService;
        public static CountryDataBase CountryDataBase { get; private set; }
        string dbPath => FileAccessHelper.GetLocalFilePath("country.db3");


        public App()
        {
            InitializeComponent();
            connection = new ConnectionChecker();
            message = new MessageManager();
            apiService = new ApiService();
            CountryDataBase = new CountryDataBase(dbPath);
            LoadCountry = new LoadCountry(new ApiService(), CountryDataBase);
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
                var list = LoadCountry.LoadCountries();
                MainViewModel.GetInstace().AfricaView = new AfricaViewModel(list);
                MainViewModel.GetInstace().AmericasView = new AmericasViewModel(list);
                MainViewModel.GetInstace().AsiaView = new AsiaViewModel(list);
                MainViewModel.GetInstace().EuropeView = new EuropeViewModel(list);
                MainViewModel.GetInstace().OceaniaView = new OceaniaViewModel(list);
                
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
