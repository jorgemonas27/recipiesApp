using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Models
{
    public class State
    {
        public bool Offline { get; set; }
        public List<Country> Countries { get; set; }
    }
}
