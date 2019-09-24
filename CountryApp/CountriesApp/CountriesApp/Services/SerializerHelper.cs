using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CountriesApp.Services
{
    public class SerializerHelper : ISerializer
    {
        public T DeserializeData<T>() where T: List<Country>
        {
            var countries = new List<Country>();
            using (Stream stream = File.Open(App.serializePath, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                countries = (List<Country>)bformatter.Deserialize(stream);
            }
            return (T)countries;
        }

        public void SerializeData<T>(T value) where T : class
        {
            using (Stream stream = File.Open(App.serializePath, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, value);
            }
        }
    }
}
