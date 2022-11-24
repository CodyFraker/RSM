using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSMModels.Models.Country
{
    [Table("countries")]
    public class Country
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [Required]
        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [Required]
        [JsonProperty("numeric_code")]
        public int NumericCode { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Required]
        [JsonProperty("currency_name")]
        public string CurrencyName { get; set; }

        [Required]
        [JsonProperty("region")]
        public string Region { get; set; }

        [Required]
        [JsonProperty("subregion")]
        public string Subregion { get; set; }

        [Required]
        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }
    }
}
