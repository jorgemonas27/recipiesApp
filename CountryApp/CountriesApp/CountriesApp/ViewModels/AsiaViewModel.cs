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
    public class AsiaViewModel: BaseViewModel
    {
        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetAsiaCountries);
            }
        }


        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchAsia);
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
        private ObservableCollection<CountryItemViewModel> asia;

        public ObservableCollection<CountryItemViewModel> Asia
        {
            get { return asia; }
            set
            {
                asia = value;
                SetValue(ref asia, value);
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
                this.SearchAsia();
            }
        }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> asiaList;

        #endregion

        #region Ctor
        public AsiaViewModel()
        {
            searchCountry = new SearchCountry();
            loadCountry = new LoadCountry();
            GetAsiaCountries();
        }
        #endregion

        #region Methods

        private async void GetAsiaCountries()
        {
            IsRunning = true;
            this.asiaList = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/asia");
            var sortedList = this.asiaList.OrderBy(country => country.Name).ToList();
            Asia = new ObservableCollection<CountryItemViewModel>(ViewModelParser.ToCountryItemViewModel(sortedList));
            IsRunning = false;
        }

        private void SearchAsia()
        {
            var countries = ViewModelParser.ToCountryItemViewModel(asiaList);
            Asia = searchCountry.SearchCountries(KeySearch, countries, Asia);
        }

        #endregion
    }
}
