using CountriesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class ApiService:IService
    {
        public IService service;

        public ApiService()
        {
            
        }

        public ApiService(IService mockService)
        {
            service = mockService;
        }

        public async Task<Response<List<Country>>> GetData(string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response<List<Country>>
                        {
                            IsSuccess = false,
                            Message = result
                        };
                    }

                    List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(result);

                    return new Response<List<Country>>
                    {
                        IsSuccess = true,
                        Message = response.StatusCode.ToString(),
                        Result = countries
                    };
                }
                catch (Exception e)
                {
                    return new Response<List<Country>>
                    {
                        IsSuccess = false,
                        Message = e.Message
                    };
                }
            }
        }
    }
}
