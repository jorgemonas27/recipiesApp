using CountriesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.DbContext
{
    public class CountryDbContext
    {
        private readonly SQLiteAsyncConnection context;

        public CountryDbContext(string path)
        {
            context = new SQLiteAsyncConnection(path);
            context.CreateTableAsync<Country>();
        }

        //public Task<int> SaveData(Country country)
        //{
        //    //if (country.Id != 0)
        //    //{
        //    //    return context.UpdateAsync(country);
        //    //}
        //    //else
        //    //{
        //    //    return context.InsertAsync(country);
        //    //}
        //    return new NotImplementedException();
        //}

        public Task<List<Country>> GetAllCountries()
        {
            return context.Table<Country>().ToListAsync();
        }
    }
}
