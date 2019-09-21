namespace CountriesApp.Services
{
    using CountriesApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class LoadCountry : ILoadCountry<Country>
    {
        #region Props

        private IService service;
        
        #endregion

        #region Ctor
        public LoadCountry()
        {
        }

        public LoadCountry(IService service)
        {
            this.service = service;
        }
        #endregion
        
        #region Methods
        public List<Country> LoadCountries()
        {
            try
            {
                var connected = App.connection.CheckConnection();
                if (!connected.Result.IsValid)
                {
                    Device.BeginInvokeOnMainThread(() => { App.message.ShowMessage(Resources.Resources.Error, Resources.Resources.ConnectivityError); });
                    return new List<Country>();
                }
                var response = Task.Run(()=>this.service.GetData(Resources.Resources.baseRequest, Resources.Resources.prefix, Resources.Resources.Api));
                if (!response.Result.IsSuccess)
                {
                    App.message.ShowMessage(Resources.Resources.Error,Resources.Resources.ConnectivityError, Resources.Resources.OkMessage);
                    return new List<Country>();
                }

                return response.Result.Result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion
    }
}
