using CountriesApp.Models;
using CountriesApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountriesApp.ViewModels
{
    public class CountryViewModel: BaseViewModel
    {
        #region Props
        public AfricaViewModel AfricaView { get; set; }
        public AmericasViewModel AmericasView { get; set; }
        public AsiaViewModel AsiaView { get; set; }
        public EuropeViewModel EuropeView { get; set; }
        public OceaniaViewModel OceaniaView { get; set; }
        #endregion

        #region Ctor

        public CountryViewModel()
        {
            AfricaView = new AfricaViewModel();
            AmericasView = new AmericasViewModel();
            AsiaView = new AsiaViewModel();
            EuropeView = new EuropeViewModel();
            OceaniaView = new OceaniaViewModel();
        }
        #endregion
    }
}
