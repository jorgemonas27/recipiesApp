using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CountriesApp.Services
{
    public class SearchCountry : ISearchCountry
    {
        private readonly ISearchCountry search;

        public SearchCountry()
        {

        }

        public SearchCountry(ISearchCountry toSearch)
        {
            search = toSearch;
        }

        public ObservableCollection<Country> SearchCountries(string keySearch, List<Country> cacheList, ObservableCollection<Country> regionCollection)
        {
            if (string.IsNullOrEmpty(keySearch))
            {
                regionCollection = new ObservableCollection<Country>(cacheList as List<Country>); //lista origi
                return regionCollection;
            }
            else
            {
                regionCollection = new ObservableCollection<Country>(cacheList.Where(country => country.Name.ToLower().Contains(keySearch)));
            }
            return regionCollection;
        }
    }
}
