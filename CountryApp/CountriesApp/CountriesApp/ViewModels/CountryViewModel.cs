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
        private MessageManager message;

        #endregion

        #region ctor
        public CountryViewModel()
        {
            loadCountry = new LoadCountry();
            searchCountry = new SearchCountry();
            navigator = new NavigationService();
            message = new MessageManager();
            CountrySelected = null;
        }
        #endregion

        #region Methods
        
        public async void GetCountries()
        {
            try
            {
                IsRefreshing = false;
                this.regionList = await loadCountry.LoadCountries(Url);
                var sortedList = regionList.OrderBy(country => country.Name).ToList();
                Region = new ObservableCollection<Country>(sortedList);

            }
            catch (Exception ex)
            {
                IsRefreshing = false;
                message.ShowMessage(Resources.Resources.Error, ex.Message);
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
