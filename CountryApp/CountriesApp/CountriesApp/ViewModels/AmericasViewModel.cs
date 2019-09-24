using CountriesApp.Models;
using CountriesApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace CountriesApp.ViewModels
{
    public class AmericasViewModel: CountryViewModel
    {
        protected override IList<Country> ListCountries { get; }

        public AmericasViewModel(State countries)
        {
            OfflineMode = countries.Offline;
            IsRefreshing = true;
            ListCountries = countries.Countries.Where(country => country.Region == Resources.Resources.AmericasURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
