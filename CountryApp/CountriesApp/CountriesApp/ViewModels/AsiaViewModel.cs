using CountriesApp.Models;
using CountriesApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountriesApp.ViewModels
{
    public class AsiaViewModel: CountryViewModel
    {
        protected override IList<Country> ListCountries { get; }

        public AsiaViewModel(State countries)
        {
            OfflineMode = countries.Offline;
            IsRefreshing = true;
            ListCountries = countries.Countries.Where(country => country.Region == Resources.Resources.AsiaURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
