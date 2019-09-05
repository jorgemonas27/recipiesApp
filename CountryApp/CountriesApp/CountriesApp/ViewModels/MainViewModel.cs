using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.ViewModels
{
    public class MainViewModel
    {
        #region Props

        public LoginViewModel LoginView { get; set; }
        public CountryViewModel CountryView { get; set; }
        public static MainViewModel Main { get; set; }
        public CountryDetailViewModel CountryDetailView { get; set; }

        #endregion

        #region ctor
        public MainViewModel()
        {
            LoginView = new LoginViewModel();
            CountryView = new CountryViewModel();
            CountryDetailView = new CountryDetailViewModel();
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
