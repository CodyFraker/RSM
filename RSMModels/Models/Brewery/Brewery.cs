using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSMModels.Models.Brewery
{
    /// <summary>
    /// Nearly duplicate interface can be found here: https://github.com/openbrewerydb/openbrewerydb/blob/master/src/utils/types.ts
    /// </summary>
    [Table("brewery")]
    public class Brewery
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("obdbid")]
        public string ObdbId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get;set; }

        [Required]
        [JsonProperty("type")]
        public virtual Type Type { get; set; }

        [Required]
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("primary_Address")]
        public string PrimaryAddress { get; set; }

        [JsonProperty("secondary_Address")]
        public string SecondaryAddress { get; set; }

        [Required]
        [JsonProperty("city_id")]
        public int City { get; set; }

        [Required]
        [JsonProperty("country_Province")]
        public string CountryProvince { get; set; }

        [Required]
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("phone_Number")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [Required]
        [JsonProperty("updated_At")]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
