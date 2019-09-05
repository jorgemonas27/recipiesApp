using CountriesApp.Models;
using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountriesApp.Converter
{
    public static class ViewModelParser
    {
        public static List<CountryItemViewModel> ToCountryItemViewModel(List<Country> sortedList)
        {
            return sortedList.Select(country => new CountryItemViewModel
            {
                Name = country.Name,
                TopLevelDomain = country.TopLevelDomain,
                Alpha2Code = country.Alpha2Code,
                Alpha3Code = country.Alpha3Code,
                CallingCodes = country.CallingCodes,
                Capital = country.Capital,
                AltSpellings = country.AltSpellings,
                Region = country.Region,
                Subregion = country.Subregion,
                Population = country.Population,
                Latlng = country.Latlng,
                Demonym = country.Demonym,
                Area = country.Area,
                Gini = country.Gini,
                Timezones = country.Timezones,
                Borders = country.Borders,
                NativeName = country.NativeName,
                NumericCode = country.NumericCode,
                Currencies = country.Currencies,
                Languages = country.Languages,
                Translations = country.Translations,
                Flag = country.Flag,
                RegionalBlocs = country.RegionalBlocs,
                Cioc = country.Cioc
            }).ToList();
        }

    }
}
