﻿using CountriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApp.Services
{
    public interface IService
    {
        Task<Response> GetCountries(string baseUrl);
    }
}