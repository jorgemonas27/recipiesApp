using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountriesApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace CountriesApp.Database
{
    public class CountryDataBase 
    {
        readonly SQLiteAsyncConnection database;

        public CountryDataBase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Country>();
        }

        public Task<List<Country>> GetAll()
        {
            try
            {
                return database.Table<Country>().ToListAsync();
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public Task Insert(Country item)
        {
            try
            {
                return database.InsertWithChildrenAsync(item);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            //context = new DatabaseContext();
            //var country = context.Countries.Find(item.Id);
            //if (country == null)
            //{
            //    context.Countries.Add(item);
            //    return;
            //}
            //context.Countries.Update(item);
            //context.SaveChanges();
        }
    }
}
