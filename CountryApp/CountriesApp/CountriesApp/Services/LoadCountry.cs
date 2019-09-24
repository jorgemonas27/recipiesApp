namespace CountriesApp.Services
{
    using CountriesApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class LoadCountry : ILoadCountry
    {
        #region Props

        private IService service;
        private ISerializer serializer;

        #endregion

        #region Ctor
        public LoadCountry()
        {
        }

        public LoadCountry(IService service, ISerializer serialize)
        {
            this.service = service;
            this.serializer = serialize;
        }

        public LoadCountry(IService service)
        {
            this.service = service;
        }
        #endregion
        
        #region Methods
        public T LoadCountries<T>() where T : State
        {
            try
            {
                State state;
                var connected = App.connection.CheckConnection();
                if (!connected.IsValid)
                {
                    Device.BeginInvokeOnMainThread(() => { App.message.ShowMessage(Resources.Resources.Error, Resources.Resources.ConnectivityError); });
                    var countries = serializer.DeserializeData<List<Country>>();
                    state = new State()
                    {
                        Offline = true,
                        Countries = countries
                    };
                    return (T)state;
                }
                var response = Task.Run(() => this.service.GetData(Resources.Resources.baseRequest, Resources.Resources.prefix, Resources.Resources.Api));
                if (!response.Result.IsSuccess)
                {
                    App.message.ShowMessage(Resources.Resources.Error, Resources.Resources.ConnectivityError, Resources.Resources.OkMessage);
                    return (T)new State();
                }
                var totalCountries = response.Result.Result;
                serializer.SerializeData(totalCountries);
                state = new State()
                {
                    Offline = false,
                    Countries = totalCountries
                };

                return (T)state;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
