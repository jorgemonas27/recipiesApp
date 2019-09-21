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

        public virtual List<Country> ListCountries { get; }

        protected SearchCountry searchCountry;
        public List<Country> RegionList { get; set; }

        private NavigationService navigator;
        private MessageManager message;
        private ILoadCountry<Country> load;
        
        #endregion

        #region ctor
        public CountryViewModel()
        {
            searchCountry = new SearchCountry();
            navigator = new NavigationService();
            message = new MessageManager();
        }
        #endregion

        #region Methods
        
        public void GetCountriesByRegion()
        {
            Region = new ObservableCollection<Country>(ListCountries);
        }

        public virtual void SearchCountry()
        {
            Region = searchCountry.SearchCountries(KeySearch, ListCountries, Region);
        }

        private void SelectedCountry(Country selectedCountry)
        {   
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            navigator.NavigatePage(Resources.Resources.CountryDetail);
        }
        #endregion
    }
}
