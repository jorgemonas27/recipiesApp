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
        public override List<Country> ListCountries { get; }

        public AmericasViewModel(List<Country> countriesList)
        {
            IsRefreshing = true;
            ListCountries = countriesList.Where(country => country.Region == Resources.Resources.AmericasURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
