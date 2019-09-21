using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface ILoadCountry<T> where T: class
    {
        List<Country> LoadCountries();
    }
}
