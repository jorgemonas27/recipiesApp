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
    public class OceaniaViewModel: CountryViewModel
    {
        protected override IList<Country> ListCountries { get; }

        public OceaniaViewModel(State countries)
        {
            OfflineMode = countries.Offline;
            IsRefreshing = true;
            ListCountries = countries.Countries.Where(country => country.Region == Resources.Resources.OceaniaURL).ToList();
            GetCountriesByRegion();
            IsRefreshing = false;
        }
    }
}
