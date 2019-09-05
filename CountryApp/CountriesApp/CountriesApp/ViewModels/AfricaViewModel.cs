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
using Xamarin.Forms;

namespace CountriesApp.ViewModels
{
    public class AfricaViewModel: BaseViewModel
    {
        #region props

        private ObservableCollection<Country> africa;

        public ObservableCollection<Country> Africa
        {
            get { return africa; }
            set
            {
                africa = value;
                SetValue(ref africa, value);
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
                this.SearchAfrica();
            }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                SetValue(ref number, value);
            }
        }


        private LoadCountry loadCountry;
        private SearchCountry searchCountry;
        private List<Country> africaCountries;
        #endregion

        #region Commands

        public Command<Country> DeleteCommand
        {
            get
            {
                return new Command<Country>(DeleteAsync);
            }
        }

        private void DeleteAsync(Country obj)
        {
            if (Africa.Remove(Africa.Where(country => country.Name == obj.Name).Single()))
            {
                Africa = new ObservableCollection<Country>(Africa);
                Number = Africa.Count;
            }
        }

      
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(GetAfricaCountries);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(SearchAfrica);
            }
        }
        
        #endregion

        #region Ctor

        public AfricaViewModel()
        {
            GetAfricaCountries();
        }

        #endregion

        #region Methods
        private async void GetAfricaCountries()
        {
            loadCountry = new LoadCountry();
            this.africaCountries = await loadCountry.LoadCountries("https://restcountries.eu/rest/v2/region/africa");
            var sortedList = africaCountries.OrderBy(country => country.Name).ToList();
            Africa = new ObservableCollection<Country>(sortedList);
        }

        private void SearchAfrica()
        {
            searchCountry = new SearchCountry();
            Africa = searchCountry.SearchCountries(KeySearch, africaCountries, Africa);
        }
        #endregion
    }
}
