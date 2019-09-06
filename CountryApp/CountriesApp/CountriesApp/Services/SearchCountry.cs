using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CountriesApp.Services
{
    public class SearchCountry : ISearchCountry<CountryItemViewModel>
    {

        public ObservableCollection<CountryItemViewModel> SearchCountries(string keySearch, List<CountryItemViewModel> cacheList, ObservableCollection<CountryItemViewModel> regionCollection)
        {
            if (string.IsNullOrEmpty(keySearch))
            {
                regionCollection = new ObservableCollection<CountryItemViewModel>(cacheList); //lista origi
                return regionCollection;
            }
            else
            {
                regionCollection = new ObservableCollection<CountryItemViewModel>(cacheList.Where(country => country.Name.ToLower().Contains(keySearch)));
            }
            return regionCollection;
        }
    }
}
