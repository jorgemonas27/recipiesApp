namespace CountriesApp.Models
{
    using Newtonsoft.Json;
    using System;

    [Serializable]
    public class RegionalBloc
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
