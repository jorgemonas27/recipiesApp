using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.ViewModels
{
    public class MainViewModel
    {
        #region Props

        public LoginViewModel LoginView { get; set; }
        //public CountryViewModel CountryView { get; set; }
        public static MainViewModel Main { get; set; }
        public CountryDetailViewModel CountryDetailView { get; set; }
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
            LoginView = new LoginViewModel();
            //CountryDetailView = new CountryDetailViewModel();
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
