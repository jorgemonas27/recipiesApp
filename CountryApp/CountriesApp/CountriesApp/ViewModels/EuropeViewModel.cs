using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CountriesApp.ViewModels
{
    public class EuropeViewModel: CountryViewModel
    {
        public override List<Country> ListCountries { get; }

        public EuropeViewModel(List<Country> countriesList)
        {
            IsRefreshing = true;
            ListCountries = countriesList.Where(country => country.Region == Resources.Resources.EuropeURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
