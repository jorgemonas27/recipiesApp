namespace CountriesApp.Models
{
    using Newtonsoft.Json;
    using System;

    [Serializable]
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
