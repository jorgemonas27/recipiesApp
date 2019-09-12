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
        private IService service;
        private MessageManager message;

        #endregion

        #region Ctor
        public LoadCountry()
        {
            service = new ApiService();
            message = new MessageManager();
        }

        public LoadCountry(IService service)
        {
            this.service = service;
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
                    message.ShowMessage(Resources.Resources.Error, response.Message, Resources.Resources.OkMessage);
                    return new List<Country>();
                }
                  
                cacheList = response.Result;
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
