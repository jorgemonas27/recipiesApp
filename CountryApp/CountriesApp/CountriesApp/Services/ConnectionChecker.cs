﻿using CountriesApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public class ConnectionChecker
    {
        public async Task<ResponseValidator> CheckConnection()
        {
            if(!CrossConnectivity.Current.IsConnected)
            {
                await Task.Delay(2000);
                return new ResponseValidator()
                {
                    IsValid = false,
                    Message = Resources.Resources.ConnectivityError
                };
            }

            var isReacheable = await CrossConnectivity.Current.IsRemoteReachable(Resources.Resources.Google);
            if (!isReacheable)
            {
                await Task.Delay(2000);
                return new ResponseValidator()
                {
                    IsValid = false,
                    Message = Resources.Resources.NoGoodSignalError
                };
            }
            return new ResponseValidator()
            {
                IsValid = true
            };
        }
    }
}