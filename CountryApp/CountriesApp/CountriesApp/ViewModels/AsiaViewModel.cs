namespace CountriesApp.ViewModels
{
    public class AsiaViewModel: CountryViewModel
    {
        public override string Url => Resources.Resources.AsiaURL;
        public AsiaViewModel()
        {
            IsRefreshing = true;
            GetCountries();
        }
    }
}
