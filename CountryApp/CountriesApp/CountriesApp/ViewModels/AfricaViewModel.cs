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
        public override List<Country> ListCountries { get; }

        public AfricaViewModel(List<Country> countriesList)
        {
            IsRefreshing = true;
            ListCountries = countriesList.Where(country => country.Region == Resources.Resources.AfricaURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
