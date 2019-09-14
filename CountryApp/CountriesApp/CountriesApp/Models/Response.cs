using System.Collections.Generic;

namespace CountriesApp.Models
{
    public class Response<T> where T: List<Country>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
