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
    public class AmericasViewModel: BaseViewModel
    {
        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetAmericasCountries);
            }
        }

      
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchAmericas);
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
        private ObservableCollection<Country> americas;

        public ObservableCollection<Country> Americas
        {
            get { return americas; }
            set
            {
                americas = value;
                SetValue(ref americas, value);
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
                this.SearchAmericas();
            }
        }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> americasList;

        #endregion

        #region Ctor
        public AmericasViewModel()
        {
            searchCountry = new SearchCountry();
            loadCountry = new LoadCountry();
            GetAmericasCountries();
        }
        #endregion

        #region Methods

        private async void GetAmericasCountries()
        {
            IsRunning = true;
            this.americasList = await loadCountry.LoadCountries(Resources.Resources.AmericasURL);
            var sortedList = this.americasList.OrderBy(country => country.Name).ToList();
            Americas = new ObservableCollection<Country>(sortedList);
            IsRunning = false;
        }

        private void SearchAmericas()
        {
            Americas = searchCountry.SearchCountries(KeySearch, americasList, Americas);
        }

        private async void SelectedCountry(Country selectedCountry)
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(selectedCountry);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage());
        }

        #endregion
    }
}
