using CountriesApp.Models;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CountriesApp.ViewModels
{
    public class MainViewModel
    {


        public ICommand SettingsCommand
        {
            get
            {
                return new RelayCommand(Settings);
            }
        }

        private async void Settings()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


        #region Props

        public LoginViewModel LoginView { get; set; }
        public CountryViewModel CountryView { get; set; }
        public static MainViewModel Main { get; set; }
        public CountryDetailViewModel CountryDetailView { get; set; }
        //public CommunPage CommunView { get; set; }
        public AfricaViewModel AfricaView { get; set; }
        public AmericasViewModel AmericasView { get; set; }
        public AsiaViewModel AsiaView { get; set; }
        public EuropeViewModel EuropeView { get; set; }
        public OceaniaViewModel OceaniaView { get; set; }

        #endregion

        #region ctor
        public MainViewModel()
        {
            Main = this;
            //CountryView = new CountryViewModel();
            LoginView = new LoginViewModel();
            AfricaView = new AfricaViewModel();
            AmericasView = new AmericasViewModel();
            AsiaView = new AsiaViewModel();
            EuropeView = new EuropeViewModel();
            OceaniaView = new OceaniaViewModel();
        }
        #endregion

        public static MainViewModel GetInstace()
        {
            if (Main == null)
            {
                return new MainViewModel();
            }
            return Main;
        }
    }
}
