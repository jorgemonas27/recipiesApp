using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CountriesApp.Models;
using CountriesApp.Services;

namespace CountriesApp.ViewModels
{
    public class AfricaViewModel: CountryViewModel
    {
        protected override IList<Country> ListCountries { get; }

        public AfricaViewModel(State countries)
        {
            OfflineMode = countries.Offline;
            IsRefreshing = true;
            ListCountries = countries.Countries.Where(country => country.Region == Resources.Resources.AfricaURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
