namespace CountriesApp.Services
{
    using CountriesApp.Database;
    using CountriesApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class LoadCountry : ILoadCountry<Country>
    {
        #region Props

        private IService service;
        private CountryDataBase database;

        #endregion

        #region Ctor
        public LoadCountry()
        {
        }

        public LoadCountry(IService service, CountryDataBase database)
        {
            this.service = service;
            this.database = database;
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
                var totalCountries = response.Result.Result;

                totalCountries.ForEach(country =>
                {
                    database.Insert(country);
                });
                //string dir = @"c:\temp";
                //string serializationFile = Path.Combine(dir, @"\countries.bin");

                ////serialize
                //using (Stream stream = File.Open(serializationFile, FileMode.Create))
                //{
                //    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                //    bformatter.Serialize(stream, totalCountries);
                //}

                ////deserialize
                //using (Stream stream = File.Open(serializationFile, FileMode.Open))
                //{
                //    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                //    List<Country> countries = (List<Country>)bformatter.Deserialize(stream);
                //}

                return totalCountries;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion
    }
}
