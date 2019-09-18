using CountriesApp.Models;
using CountriesApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace CountriesTest
{
    [TestClass]
    public class CountryTest
    {
        Response<List<Country>> responseAll;
        Response<List<Country>> responseRegion;

        public CountryTest()
        {
            MockForms.Init();
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
            var baseURL = "https://restcountries.eu";
            var prefix = "/rest";
            var controller = "/v2/all";
            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL, prefix, controller)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL, prefix, controller).Result;

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Get_All_Countries_From_Service()
        {
            var baseURL = "https://restcountries.eu";
            var prefix = "/rest";
            var controller = "/v2/all";
            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL, prefix, controller)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL, prefix, controller).Result;
            var expectedResult = 250;

            Assert.AreEqual(expectedResult, actualResult.Result.Count);
        }

        [TestMethod]
        public void Get_Not_Null_Countries_Of_A_Region_Information_Since_A_Service()
        {
            var baseURL = "https://restcountries.eu";
            var prefix = "/rest";
            var controller = "/v2/all";
            var mockAPI = new Mock<IService>();
            mockAPI.Setup(sp => sp.GetData(baseURL, prefix, controller)).ReturnsAsync(responseAll);
            ApiService apiService = new ApiService(mockAPI.Object);
            var actualResult = apiService.GetData(baseURL, prefix, controller).Result;

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Load_Correctly_Countries_Of_A_Region_Information_Since_A_Service()
        {
            var baseURL = "https://restcountries.eu";
            var prefix = "/rest";
            var controller = "/v2/region/africa";
            var mockServices = new Mock<IService>();
            responseRegion.Result = responseAll.Result.Where(country => country.Region == "Africa").ToList();
            mockServices.Setup(sp => sp.GetData(baseURL, prefix, controller)).ReturnsAsync(responseRegion);
            LoadCountry loadCountry = new LoadCountry(mockServices.Object);
            var actualResult = loadCountry.LoadCountries(controller);
            var expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult.Result.Count);
        }

        [TestMethod]
        public void Return_A_Valid_Collection_Of_Countries_That_Contains_The_Keyword()
        {
            var keyword = "ia";
            var mockLoad = new Mock<ISearchCountry>();
            responseRegion.Result = responseAll.Result.Where(country => country.Name.ToLower().Contains(keyword)).ToList();
            var countries = new ObservableCollection<Country>(responseAll.Result);
            var countriesResult = new ObservableCollection<Country>(responseRegion.Result);
            mockLoad.Setup(sp => sp.SearchCountries(keyword, responseRegion.Result, countries))
                .Returns(countriesResult);
            SearchCountry search = new SearchCountry(mockLoad.Object);
            var actualResult = search.SearchCountries(keyword, responseRegion.Result, countries);

            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Returns_The_Total_Number_Of_Countries_That_Contains_The_Keyword()
        {
            var keyword = "ia";
            var mockSearch = new Mock<ISearchCountry>();
            responseRegion.Result = responseAll.Result.Where(country => country.Name.ToLower().Contains(keyword)).ToList();
            var countries = new ObservableCollection<Country>(responseAll.Result);
            var countriesResult = new ObservableCollection<Country>(responseRegion.Result);
            mockSearch.Setup(sp => sp.SearchCountries(keyword, responseRegion.Result, countries))
                .Returns(countriesResult);
            SearchCountry search = new SearchCountry(mockSearch.Object);
            var actualResult = search.SearchCountries(keyword, responseRegion.Result, countries);
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, actualResult.Count);
        }

        [TestMethod]
        public void Return_The_Same_List_When_The_Keyword_Is_Empty()
        {
            var keyword = string.Empty;
            var mockSearch = new Mock<ISearchCountry>();
            responseRegion.Result = responseAll.Result.Where(country => country.Name.ToLower().Contains(keyword)).ToList();
            var countries = new ObservableCollection<Country>(responseAll.Result);
            var countriesResult = new ObservableCollection<Country>(responseRegion.Result);
            mockSearch.Setup(sp => sp.SearchCountries(keyword, responseRegion.Result, countries))
                .Returns(countriesResult);
            SearchCountry search = new SearchCountry(mockSearch.Object);
            var actualResult = search.SearchCountries(keyword, responseRegion.Result, countries);
            var expectedResult = 8;

            Assert.AreEqual(expectedResult, actualResult.Count);
        }

        [TestMethod]
        public void Valid_User_Credentials_For_Login()
        {
            var email = "jorgehmg17@gmail.com";
            var password = "1234";
            var mockLogin = new Mock<IAuth>();
            mockLogin.Setup(sp => sp.LoginUser(email, password)).ReturnsAsync(true);
            Login login = new Login(mockLogin.Object);
            var actualResult = login.LoginUser(email, password);

            Assert.IsTrue(actualResult.Result);
        }

        [TestMethod]
        public void Invalid_User_Credentials_For_Login()
        {
            var email = "jorgehmsg17@gmail.com";
            var password = "123dsadsds4";
            var mockLogin = new Mock<IAuth>();
            mockLogin.Setup(sp => sp.LoginUser(email, password)).ReturnsAsync(true);
            Login login = new Login(mockLogin.Object);
            var actualResult = login.LoginUser(email, password);

            Assert.IsFalse(actualResult.Result);
        }

        [TestMethod]
        public void Invalid_Email_Of_A_User_For_Login()
        {
            var email = "jorgegmail";
            var password = "123dsadsds4";
            var mockLogin = new Mock<IAuth>();
            mockLogin.Setup(sp => sp.LoginUser(email, password)).ReturnsAsync(true);
            Login login = new Login(mockLogin.Object);
            var actualResult = login.LoginUser(email, password);

            Assert.IsFalse(actualResult.Result);
        }

        [TestMethod]
        public void The_Email_Or_Password_Of_A_User_For_Login_Is_Empty()
        {
            var email = string.Empty;
            var password = string.Empty;
            var mockLogin = new Mock<IAuth>();
            mockLogin.Setup(sp => sp.LoginUser(email, password)).ReturnsAsync(true);
            Login login = new Login(mockLogin.Object);
            var actualResult = login.LoginUser(email, password);

            Assert.IsFalse(actualResult.Result);
        }
    }
}
