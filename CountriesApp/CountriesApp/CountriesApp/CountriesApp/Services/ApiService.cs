using CountriesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class ApiService
    {
        public async Task<Response> GetCountries<T>(string baseUrl, string servicePrefix, string controller)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var url = $"{servicePrefix}{controller}";
                    var response = await client.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            IsSuccess = false,
                            Message = result
                        };
                    }

                    List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(result);

                    return new Response
                    {
                        IsSuccess = true,
                        Message = response.StatusCode.ToString(),
                        Result = countries
                    };
                }
                catch (Exception e)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = e.Message
                    };
                }
            }
        }
    }
}
