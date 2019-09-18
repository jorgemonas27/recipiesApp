namespace CountriesApp.ViewModels
{
    public class AmericasViewModel: CountryViewModel
    {
        public override string Url => Resources.Resources.AmericasURL;
        public AmericasViewModel()
        {
            IsRefreshing = true;
            GetCountries();
        }
    }
}
