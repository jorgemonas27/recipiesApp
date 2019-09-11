using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.ViewModels
{
    public class CommunPage
    {
        public AfricaViewModel AfricaView { get; set; }
        public AmericasViewModel AmericasView { get; set; }
        public AsiaViewModel AsiaView { get; set; }
        public EuropeViewModel EuropeView { get; set; }
        public OceaniaViewModel OceaniaView { get; set; }

        public CommunPage()
        {
            //LoginView = new LoginViewModel();
            AfricaView = new AfricaViewModel();
            AmericasView = new AmericasViewModel();
            AsiaView = new AsiaViewModel();
            EuropeView = new EuropeViewModel();
            OceaniaView = new OceaniaViewModel();
        }
    }
}
