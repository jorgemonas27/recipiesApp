namespace CountriesApp.Services
{
    using CountriesApp.Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService
    {
        public async void NavigatePage(string page)
        {
            switch (page)
            {
                case "CountriesPage":
                    await Navigate(new CountriesPage());
                    break;
                case "DetailsCountry":
                    await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage(), true);
                    break;
                case "LoginPage":
                    await Navigate(new LoginPage());
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            if (typeof(T) == typeof(LoginPage))
            {
                NavigationPage.SetHasNavigationBar(page, false);
            }
            NavigationPage.SetHasBackButton(page, false);
            NavigationPage.SetBackButtonTitle(page, "Back");
            await App.Current.MainPage.Navigation.PushAsync(page, true);
        }
    }
}
