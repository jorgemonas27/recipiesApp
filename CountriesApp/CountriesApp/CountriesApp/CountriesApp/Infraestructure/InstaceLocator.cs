using CountriesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Infraestructure
{
    public class InstaceLocator
    {
        public MainViewModel Main { get; set; }
        public InstaceLocator()
        {
            Main = new MainViewModel();
        }

    }
}
