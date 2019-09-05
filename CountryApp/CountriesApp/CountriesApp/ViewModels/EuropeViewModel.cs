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

namespace CountriesApp.ViewModels
{
    public class EuropeViewModel: BaseViewModel
    {
        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetEuropeCountries);
            }
        }


        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchEurope);
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


        #region Props
        private ObservableCollection<CountryItemViewModel> europe;

        public ObservableCollection<CountryItemViewModel> Europe
        {
            get { return europe; }
            set
            {
                europe = value;
                SetValue(ref europe, value);
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
                this.SearchEurope();
            }
        }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> europeList;

        #endregion

        #region Ctor
        public EuropeViewModel()
        {
            loadCountry = new LoadCountry();
            searchCountry = new SearchCountry();
            GetEuropeCountries();
        }
        #endregion

        #region Methods

        private async void GetEuropeCountries()
        {
            this.europeList = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/europe");
            var sortedList = this.europeList.OrderBy(country => country.Name).ToList();
            Europe = new ObservableCollection<CountryItemViewModel>(ViewModelParser.ToCountryItemViewModel(sortedList));
        }

        private void SearchEurope()
        {
            var countries = ViewModelParser.ToCountryItemViewModel(europeList);
            Europe = searchCountry.SearchCountries(KeySearch, countries, Europe);
        }
        #endregion
    }
}
