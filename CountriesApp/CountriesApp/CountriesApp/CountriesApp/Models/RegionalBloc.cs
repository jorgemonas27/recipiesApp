using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Models
{
    public class RegionalBloc
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
