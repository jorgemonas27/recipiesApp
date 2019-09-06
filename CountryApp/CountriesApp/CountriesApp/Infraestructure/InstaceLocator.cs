namespace CountriesApp.Infraestructure
{
    using CountriesApp.ViewModels;
    public class InstaceLocator
    {
        public MainViewModel Main { get; set; }
        public InstaceLocator()
        {
            Main = new MainViewModel();
        }

    }
}
