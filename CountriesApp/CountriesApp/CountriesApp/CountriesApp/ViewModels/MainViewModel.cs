using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel LoginView { get; set; }
        public CountryViewModel CountryView { get; set; }
        public static MainViewModel Main { get; set; }

        public MainViewModel()
        {
            LoginView = new LoginViewModel();
        }

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
