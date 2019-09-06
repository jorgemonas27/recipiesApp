using CountriesApp.Models;
using CountriesApp.Services;
using CountriesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CountriesApp.ViewModels
{
    public class CountryItemViewModel: Country 
    {
        #region Command
        public ICommand DetailsCommand
        {
            get
            {
                return new RelayCommand(DetailsAsync);
            }
        }
        #endregion

        #region Methods
        private async void DetailsAsync()
        {
            MainViewModel.GetInstace().CountryDetailView = new CountryDetailViewModel(this);
            await App.Current.MainPage.Navigation.PushAsync(new CountryDetailPage()); 
        }

        #endregion
    }
}
