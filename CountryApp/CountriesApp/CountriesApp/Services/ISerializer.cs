using CountriesApp.Models;
using System.Collections.Generic;

namespace CountriesApp.Services
{
    public interface ISerializer
    {
        void SerializeData<T>(T value) where T: class;
        T DeserializeData<T>() where T: List<Country>;
    }
}
