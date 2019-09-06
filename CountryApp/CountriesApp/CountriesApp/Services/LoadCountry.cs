namespace CountriesApp.Services
{
    using CountriesApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
