namespace CountriesApp.ViewModels
{
    using System.Windows.Input;
    using CountriesApp.Views;
    using GalaSoft.MvvmLight.Command;

    public class MainViewModel
    {

        #region Commands

        public ICommand SettingsCommand
        {
            get
            {
                return new RelayCommand(Settings);
            }
        }

        #endregion

        #region Props

        public static MainViewModel Main { get; set; }
        public LoginViewModel LoginView { get; set; }
        public CountryViewModel CountryView { get; set; }
        public CountryDetailViewModel CountryDetailView { get; set; }
        public AfricaViewModel AfricaView { get; set; }
        public AmericasViewModel AmericasView { get; set; }
        public AsiaViewModel AsiaView { get; set; }
        public EuropeViewModel EuropeView { get; set; }
        public OceaniaViewModel OceaniaView { get; set; }

        #endregion

        #region Ctor

        public MainViewModel()
        {
            Main = this;
            LoginView = new LoginViewModel();
            AfricaView = new AfricaViewModel();
            AmericasView = new AmericasViewModel();
            AsiaView = new AsiaViewModel();
            EuropeView = new EuropeViewModel();
            OceaniaView = new OceaniaViewModel();
        }
        #endregion

        #region Methods

        private async void Settings()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        public static MainViewModel GetInstace()
        {
            if (Main == null)
            {
                return new MainViewModel();
            }
            return Main;
        }

        #endregion

    }
}
