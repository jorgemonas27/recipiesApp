using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.Models
{
    public class Currency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
