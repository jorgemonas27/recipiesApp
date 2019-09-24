using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Database
{
    public interface IEntityFrameworkService
    {
        IList<Country> GetAll();
        void Insert(Country item);
    }
}
