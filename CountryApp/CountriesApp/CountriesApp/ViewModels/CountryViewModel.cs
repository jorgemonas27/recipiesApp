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
    public class CountryViewModel: BaseViewModel
    {

        #region Commands
        public ICommand RefreshCommand
        {
            get => new RelayCommand(GetCountries);
        }

        public ICommand SearchCommand
        {
            get => new RelayCommand(SearchCountry);
        }

        public ICommand SelectedItemCommand
        {
            get => new RelayCommand<Country>(SelectedCountry);
        }

        #endregion

        #region Props
        private ObservableCollection<Country> region;

        public ObservableCollection<Country> Region
        {
            get { return region; }
            set
            {
                region = value;
                SetValue(ref region, value);
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

        private bool isrefreshing;

        public bool IsRefreshing
        {
            get { return isrefreshing; }
            set
            {
                isrefreshing = value;
                SetValue(ref isrefreshing, value);
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
                this.SearchCountry();
            }
        }

        public virtual string Url { get; }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> regionList;

        public Country CountrySelected { get; set; }
        private NavigationService navigator;
        private ConnectionChecker connection;
        private MessageManager message;

        public static CountryViewModel Instance { get; set; }
        #endregion

        #region ctor
        public CountryViewModel()
        {
            Instance = this;
            loadCountry = new LoadCountry();
            searchCountry = new SearchCountry();
            navigator = new NavigationService();
            message = new MessageManager();
            CountrySelected = null;
            GetCountries();
        }
        #endregion

        #region Methods

        public static CountryViewModel GetInstance()
        {
            if (Instance == null)
            {
                return new CountryViewModel();
            }
            return Instance;
        }

        private async void GetCountries()
        {
            try
            {
                IsRunning = true;
                this.regionList = await loadCountry.LoadCountries(Url);
                var sortedList = regionList.OrderBy(country => country.Name).ToList();
                Region = new ObservableCollection<Country>(sortedList);
                IsRunning = false;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            
        }
        
        private void SearchCountry()
        {
            Region = searchCountry.SearchCountries(KeySearch, regionList, Region);
        }

        private void SelectedCountry(Country selectedCountry)
        {   
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            navigator.NavigatePage(Resources.Resources.CountryDetail);
        }
        #endregion
    }
}
