using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class LoadCountry : ILoadCountry<Country>
    {
        public List<Country> cacheList { get; set; }

        private ApiService service;
        private MessageManager message;

        public LoadCountry()
        {
            service = new ApiService();
            message = new MessageManager();
        }
        
        public async Task<List<Country>> LoadCountries(string baseURL)
        {
            try
            {
                var response = await service.GetCountries(baseURL);
                if (!response.IsSuccess)
                {
                    message.ShowMessage("Error", response.Message, "Ok");
                    return new List<Country>();
                }

                cacheList = (List<Country>)response.Result;
                return cacheList;
                //var sortedList = cacheList.OrderBy(country => country.Name).ToList();
                //regionCollection = new ObservableCollection<Country>(sortedList);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
