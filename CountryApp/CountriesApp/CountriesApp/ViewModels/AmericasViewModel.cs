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
            GetAmericasCountries();
        }
        #endregion

        #region Methods

        private async void GetAmericasCountries()
        {
            loadCountry = new LoadCountry();
            this.americasList = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/americas");
            var sortedList = this.americasList.OrderBy(country => country.Name).ToList();
            Americas = new ObservableCollection<Country>(sortedList);    
        }

        private void SearchAmericas()
        {
            Americas = searchCountry.SearchCountries(KeySearch, americasList, Americas);
        }
        
        #endregion
    }
}
