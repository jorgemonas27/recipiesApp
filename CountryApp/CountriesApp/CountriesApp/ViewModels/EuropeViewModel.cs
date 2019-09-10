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

        public ICommand SelectedItemCommand
        {
            get
            {
                return new RelayCommand<Country>(SelectedCountry);
            }
        }
        
        #endregion


        #region Props
        private ObservableCollection<Country> europe;

        public ObservableCollection<Country> Europe
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
            IsRunning = true;
            this.europeList = await loadCountry.LoadCountries(Resources.Resources.EuropeURL);
            var sortedList = this.europeList.OrderBy(country => country.Name).ToList();
            Europe = new ObservableCollection<Country>(sortedList);
            IsRunning = false;
        }

        private void SearchEurope()
        {
            Europe = searchCountry.SearchCountries(KeySearch, europeList, Europe);
        }

        private async void SelectedCountry(Country selectedCountry)
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage());
        }

        #endregion
    }
}
