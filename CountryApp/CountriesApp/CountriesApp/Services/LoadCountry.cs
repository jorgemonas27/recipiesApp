namespace CountriesApp.Services
{
    using CountriesApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LoadCountry : ILoadCountry<Country>
    {
        #region Props
        public List<Country> cacheList { get; set; }
        private ApiService service;
        private MessageManager message;

        #endregion

        #region Ctor
        public LoadCountry()
        {
            service = new ApiService();
            message = new MessageManager();
        }
        #endregion

        #region Methods
        public async Task<List<Country>> LoadCountries(string baseURL)
        {
            try
            {
                var response = await service.GetData(baseURL);
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

        #endregion
    }
}
