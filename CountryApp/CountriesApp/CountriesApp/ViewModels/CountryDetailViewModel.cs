using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace CountriesApp.ViewModels
{
    public class CountryDetailViewModel: BaseViewModel
    {
        #region Props

        private Country country;

        public Country Country
        {
            get { return country; }
            set
            {
                country = value;
                SetValue(ref country, value);
            }
        }

        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }

        #endregion

        #region Ctor

        public CountryDetailViewModel(Country selectedCountry)
        {
            this.Country = selectedCountry;
            this.Currencies = this.Country.Currencies;
            this.Languages = this.Country.Languages;
        }

        #endregion


    }
}
