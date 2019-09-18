using CountriesApp.Services;

namespace CountriesApp.ViewModels
{
    public class AfricaViewModel: CountryViewModel
    {
        public override string Url => Resources.Resources.AfricaURL;
        public AfricaViewModel()
        {
            IsRefreshing = true;
            GetCountries();
        }
    }
}
