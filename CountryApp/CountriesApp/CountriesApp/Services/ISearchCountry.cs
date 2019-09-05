using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CountriesApp.Services
{
    interface ISearchCountry<T> where T: CountryItemViewModel 
    {
        ObservableCollection<T> SearchCountries(string keySearch, List<T> cacheList, ObservableCollection<T> regionCollection);
    }
}
