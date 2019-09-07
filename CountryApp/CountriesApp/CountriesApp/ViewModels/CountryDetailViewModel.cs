using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

        public Currency Currency { get; set; }
        public Language Languages { get; set; }

        public List<List<object>> Info;

        #endregion

        #region Ctor

        public CountryDetailViewModel(Country selectedCountry)
        {
            this.Country = selectedCountry;
            this.Currency = this.Country.Currencies.FirstOrDefault();
            this.Languages = this.Country.Languages.FirstOrDefault();
        }

        #endregion
    }
}
