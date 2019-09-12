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

        #endregion

        #region ctor
        public CountryViewModel()
        {
            loadCountry = new LoadCountry();
            searchCountry = new SearchCountry();
            GetCountries();
        }
        #endregion

        #region Methods
        private async void GetCountries()
        {
            IsRunning = true;
            this.regionList = await loadCountry.LoadCountries(Url);
            var sortedList = regionList.OrderBy(country => country.Name).ToList();
            Region = new ObservableCollection<Country>(sortedList);
            IsRunning = false;
        }

        private void SearchCountry()
        {
            Region = searchCountry.SearchCountries(KeySearch, regionList, Region);
        }

        private async void SelectedCountry(Country selectedCountry)
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage(), true);
        }
        #endregion
    }
}
