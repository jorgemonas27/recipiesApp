using CountriesApp.Converter;
using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CountriesApp.ViewModels
{
    public class AfricaViewModel: BaseViewModel
    {
        #region props

        private ObservableCollection<CountryItemViewModel> africa;

        public ObservableCollection<CountryItemViewModel> Africa
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

        public ICommand DetailsCommand
        {
            get
            {
                return new RelayCommand(Details);
            }
        }

        private async void Details()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage());
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
            this.africaCountries = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/africa");
            var sortedList = africaCountries.OrderBy(country => country.Name).ToList();
            Africa = new ObservableCollection<CountryItemViewModel>(ViewModelParser.ToCountryItemViewModel(sortedList));
        }

        private void SearchAfrica()
        {
            var countries = ViewModelParser.ToCountryItemViewModel(africaCountries);
            Africa = searchCountry.SearchCountries(KeySearch, countries, Africa);
        }

        #endregion
    }
}
