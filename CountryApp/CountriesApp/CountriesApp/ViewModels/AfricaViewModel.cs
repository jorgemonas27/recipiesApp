using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CountriesApp.ViewModels
{
    public class AfricaViewModel: BaseViewModel
    {
        #region props

        private ObservableCollection<Country> africa;

        public ObservableCollection<Country> Africa
        {
            get { return africa; }
            set
            {
                africa = value;
                SetValue(ref africa, value);
            }
        }

        private bool isrunning;

        public bool IsRunning
        {
            get { return isrunning; }
            set
            {
                isrunning = value;
                SetValue(ref isrunning, value);
            }
        }

        private string keySearch;

        public string KeySearch
        {
            get { return keySearch; }
            set
            {
                keySearch = value;
                SetValue(ref keySearch, value);
                this.SearchAfrica();
            }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                SetValue(ref number, value);
            }
        }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> africaCountries;
        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetAfricaCountries);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchAfrica);
            }
        }

        public ICommand SelectedItemCommand
        {
            get
            {
                return new RelayCommand<Country>(SelectedCountry);
            }
        }

        #endregion

        #region Ctor

        public AfricaViewModel()
        {
            loadCountry = new LoadCountry();
            searchCountry = new SearchCountry();
            GetAfricaCountries();
        }

        #endregion

        #region Methods
        private async void GetAfricaCountries()
        {
            IsRunning = true;
            this.africaCountries = await loadCountry.LoadCountries(Resources.Resources.AfricaURL);
            var sortedList = africaCountries.OrderBy(country => country.Name).ToList();
            Africa = new ObservableCollection<Country>(sortedList);
            IsRunning = false;
        }

        private void SearchAfrica()
        {
            Africa = searchCountry.SearchCountries(KeySearch, africaCountries, Africa);
        }

        private async void SelectedCountry(Country selectedCountry)
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage());
        }


        #endregion
    }
}
