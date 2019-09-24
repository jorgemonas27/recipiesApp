using CountriesApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class ConnectionChecker
    {
        public ResponseValidator CheckConnection()
        {
            if(!CrossConnectivity.Current.IsConnected)
            {
                return new ResponseValidator()
                {
                    IsValid = false,
                    Message = Resources.Resources.ConnectivityError
                };
            }
            return new ResponseValidator()
            {
                IsValid = true
            };
        }
    }
}
