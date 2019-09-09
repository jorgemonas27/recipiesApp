using CountriesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class ApiService:IService
    {

        public async Task<Response> GetData(string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl);
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
