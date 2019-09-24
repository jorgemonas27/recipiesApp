namespace CountriesApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    using SQLite;
    using SQLiteNetExtensions.Attributes;

    [Serializable]
    public class Country
    {
        [Key, AutoIncrement]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [TextBlob("TopLevelDomainBlobbled")]
        [JsonProperty(PropertyName = "topLevelDomain")]
        public List<string> TopLevelDomain { get; set; }
        public string TopLevelDomainBlobbled { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonProperty(PropertyName = "alpha3Code")]
        public string Alpha3Code { get; set; }

        [TextBlob("CallingCodesBlobbled")]
        [JsonProperty(PropertyName = "callingCodes")]
        public List<string> CallingCodes { get; set; }
        public string CallingCodesBlobbled { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string Capital { get; set; }

        [TextBlob("AltSpellingsBlobbled")]
        [JsonProperty(PropertyName = "altSpellings")]
        public List<string> AltSpellings { get; set; }
        public string AltSpellingsBlobbled { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "subregion")]
        public string Subregion { get; set; }

        [JsonProperty(PropertyName = "population")]
        public int Population { get; set; }

        [TextBlob("LatlngBlobbled")]
        [JsonProperty(PropertyName = "latlng")]
        public List<double> Latlng { get; set; }
        public string LatlngBlobbled { get; set; }

        [JsonProperty(PropertyName = "demonym")]
        public string Demonym { get; set; }

        [JsonProperty(PropertyName = "area")]
        public double? Area { get; set; }

        [JsonProperty(PropertyName = "gini")]
        public double? Gini { get; set; }

        [TextBlob("TimezonesBlobbled")]
        [JsonProperty(PropertyName = "timezones")]
        public List<string> Timezones { get; set; }
        public string TimezonesBlobbled { get; set; }

        [TextBlob("BordersBlobbled")]
        [JsonProperty(PropertyName = "borders")]
        public List<string> Borders { get; set; }
        public string BordersBlobbled { get; set; }

        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; set; }

        [JsonProperty(PropertyName = "numericCode")]
        public string NumericCode { get; set; }

        [TextBlob("CurrenciesBlobbled")]
        [JsonProperty(PropertyName = "currencies")]
        public List<Currency> Currencies { get; set; }
        public string CurrenciesBlobbled { get; set; }

        [TextBlob("LanguagesBlobbled")]
        [JsonProperty(PropertyName = "languages")]
        public List<Language> Languages { get; set; }
        public string LanguagesBlobbled { get; set; }

        [JsonProperty(PropertyName = "translations")]
        public Translation Translations { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public string Flag{ get; set; }

        [TextBlob("RegionalBlocsBlobbled")]
        [JsonProperty(PropertyName = "regionalBlocs")]
        public List<RegionalBloc> RegionalBlocs { get; set; }
        public string RegionalBlocsBlobbled { get; set; }

        [JsonProperty(PropertyName = "cioc")]
        public string Cioc { get; set; }
    }
}
