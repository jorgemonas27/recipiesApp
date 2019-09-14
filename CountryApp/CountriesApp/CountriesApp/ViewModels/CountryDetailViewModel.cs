using CountriesApp.Models;
using System.Linq;

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
