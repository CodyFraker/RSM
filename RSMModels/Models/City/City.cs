using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMModels.Models.City
{
    [Table("cities")]
    public class City
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("state_id")]
        public int StateId { get; set; }

        [Required]
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [Required]
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [Required]
        [JsonProperty("wikiDataId")]
        public string WikiData { get; set; }
    }
}
