using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CountriesApp.ViewModels
{
    public class CountryViewModel: BaseViewModel
    {

        #region Commands

        public ICommand RefreshCommand
        {
            get => new RelayCommand(GetCountriesByRegion);
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
        private ObservableCollection<Country> countries;

        public virtual ObservableCollection<Country> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
                SetValue(ref countries, value);
            }
        }
        private ObservableCollection<Country> region;

        public virtual ObservableCollection<Country> Region
        {
            get { return region; }
            set
            {
                region = value;
                SetValue(ref region, value);
            }
        }

        private bool notFound;

        public bool NotFound
        {
            get { return notFound; }
            set
            {
                notFound = value;
                SetValue(ref notFound, value);
            }
        }

        private bool isShowing = true;

        public bool IsShowing
        {
            get { return isShowing; }
            set { isShowing = value; }
        }

        private bool offlineMode;

        public bool OfflineMode
        {
            get { return offlineMode; }
            set
            {
                offlineMode = value;
                SetValue(ref offlineMode, value);
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

        protected virtual IList<Country> ListCountries { get; }
        protected ISearchCountry searchCountry;
        private NavigationService navigator;
        
        #endregion

        #region ctor
        public CountryViewModel()
        {
            searchCountry = new SearchCountry();
            navigator = new NavigationService();
        }
        #endregion

        #region Methods
        
        public void GetCountriesByRegion()
        {
            Region = new ObservableCollection<Country>(ListCountries);
            IsRefreshing = false;
        }

        public virtual void SearchCountry()
        {
            Region = searchCountry.SearchCountries(KeySearch, ListCountries, Region);
            if (Region.Count == 0)
            {
                this.NotFound = true;
                this.IsShowing = false;
                return;
            }
            this.NotFound = false;
            this.IsShowing = true;
        }

        private void SelectedCountry(Country selectedCountry)
        {   
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            navigator.NavigatePage(Resources.Resources.CountryDetail);
        }
        #endregion
    }
}
