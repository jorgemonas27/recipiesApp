using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CountriesApp.Services
{
    public interface ISearchCountry
    {
        ObservableCollection<Country> SearchCountries(string keySearch, List<Country> cacheList, ObservableCollection<Country> regionCollection);
    }
}
