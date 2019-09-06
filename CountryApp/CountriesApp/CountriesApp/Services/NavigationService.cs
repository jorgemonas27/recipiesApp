using CountriesApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Services
{
    public static class NavigationService
    {
        public async static void NavigatePage(string page)
        {
            switch (page)
            {
                case "CountriesPage":
                    await App.Navigator.PushAsync(new CountriesPage());
                    break;
                case "DetailsCountry":
                    await App.Navigator.PushAsync(new CountryDetailPage());
                    break;
                default:
                    break;
            }
        }
    }
}
