using CountriesApp.Models;
using CountriesApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CountriesTest
{
    [TestClass]
    public class CountryTest
    {
        Response<List<Country>> responseAll;
        Response<List<Country>> responseRegion;

        public CountryTest()
        {
            responseRegion = new Response<List<Country>>()
            {
                IsSuccess = true,
                Message = "true",
                Result = new List<Country>()
            };

            responseAll = new Response<List<Country>>()
            {
                IsSuccess = true,
                Message = "true",
                Result = new List<Country>()
                {
                    new Country()
                    {
                        Name = "Argelia",
                        Capital = "Argelia",
                        Region = "Africa"
                    },
                    new Country()
                    {
                        Name = "Egypto",
                        Capital = "Cairo",
                        Region = "Africa"
                    },
                    new Country()
                    {
                        Name = "Alemania",
                        Capital = "Berlin",
                        Region = "Europe"
                    },
                    new Country()
                    {
                        Name = "Inglaterra",
                        Capital = "Londres",
                        Region = "Europe"
                    },
                    new Country()
                    {
                        Name = "Argentina",
                        Capital = "Buenos Aires",
                        Region = "Europe"
                    },
                    new Country()
                    {
                        Name = "Bolivia",
                        Capital = "Sucre",
                        Region = "Europe"
                    },
                    new Country()
                    {
                        Name = "China",
                        Capital = "Beijing",
                        Region = "Europe"
                    },
                    new Country()
                    {
                        Name = "Japon",
                        Capital = "Tokio",
                        Region = "Europe"
                    }
                }
            };
        }

        [TestMethod]
        public void Get_Not_Null_Data_From_Service()
        {
            var baseURL = "https://restcountries.eu/rest/v2/all";

            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL).Result;

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Get_All_Countries_From_Service()
        {
            var baseURL = "https://restcountries.eu/rest/v2/all";

            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL).Result;
            var expectedResult = 250;

            Assert.AreEqual(expectedResult, actualResult.Result.Count);
        }

        [TestMethod]
        public void Get_Not_Null_Countries_Of_A_Region_Information_Since_A_Service()
        {
            var baseURL = "https://restcountries.eu/rest/v2/region/africa";

            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL).Result;

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Load_Correctly_Countries_Of_A_Region_Information_Since_A_Service()
        {
            var baseURL = "https://restcountries.eu/rest/v2/region/africa";

            var mockServices = new Mock<IService>();
            responseRegion.Result = responseAll.Result.Where(country => country.Region == "Africa").ToList();

            mockServices.Setup(sp => sp.GetData(baseURL)).ReturnsAsync(responseRegion); //q cuando invoken el metodo get data retorne response
            LoadCountry loadCountry = new LoadCountry(mockServices.Object);

            var actualResult = loadCountry.LoadCountries(baseURL);
            var expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult.Result.Count);
        }
    }
}
