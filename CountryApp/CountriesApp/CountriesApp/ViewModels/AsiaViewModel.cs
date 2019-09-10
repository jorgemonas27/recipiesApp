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

        public ICommand SelectedItemCommand
        {
            get
            {
                return new RelayCommand<Country>(SelectedCountry);
            }
        }
 
        #endregion

        #region Props
        private ObservableCollection<Country> asia;

        public ObservableCollection<Country> Asia
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
            this.asiaList = await loadCountry.LoadCountries(Resources.Resources.AsiaURL);
            var sortedList = this.asiaList.OrderBy(country => country.Name).ToList();
            Asia = new ObservableCollection<Country>(sortedList);
            IsRunning = false;
        }

        private void SearchAsia()
        {
            Asia = searchCountry.SearchCountries(KeySearch, asiaList, Asia);
        }

        private async void SelectedCountry(Country selectedCountry)
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage());
        }

        #endregion
    }
}
