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
    public class OceaniaViewModel: BaseViewModel
    {
        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetOceaniaCountries);
            }
        }


        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchOceania);
            }
        }

        #endregion


        #region Props
        private ObservableCollection<Country> oceania;

        public ObservableCollection<Country> Oceania
        {
            get { return oceania; }
            set
            {
                oceania = value;
                SetValue(ref oceania, value);
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
                this.SearchOceania();
            }
        }

        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> oceaniaList;

        #endregion

        #region Ctor
        public OceaniaViewModel()
        {
            searchCountry = new SearchCountry();
            GetOceaniaCountries();
        }
        #endregion

        #region Methods

        private async void GetOceaniaCountries()
        {
            loadCountry = new LoadCountry();
            this.oceaniaList = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/oceania");
            var sortedList = this.oceaniaList.OrderBy(country => country.Name).ToList();
            Oceania = new ObservableCollection<Country>(sortedList);
        }

        private void SearchOceania()
        {
            Oceania = searchCountry.SearchCountries(KeySearch, oceaniaList, Oceania);
        }

        #endregion
    }
}
