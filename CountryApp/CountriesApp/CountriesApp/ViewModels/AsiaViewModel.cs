using CountriesApp.Models;
using CountriesApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountriesApp.ViewModels
{
    public class AsiaViewModel: CountryViewModel
    {
        public override List<Country> ListCountries { get; }

        public AsiaViewModel(List<Country> countriesList)
        {
            IsRefreshing = true;
            ListCountries = countriesList.Where(country => country.Region == Resources.Resources.AsiaURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
