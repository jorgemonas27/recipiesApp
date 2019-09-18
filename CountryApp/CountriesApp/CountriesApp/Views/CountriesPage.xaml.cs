using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : TabbedPage
    {
        private CountryViewModel countryViewModel;

        public CountriesPage()
        {
            InitializeComponent();
        }
    }
}