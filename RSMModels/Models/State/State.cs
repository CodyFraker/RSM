using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMModels.Models.State
{
    [Table("states")]
    public class State
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [Required]
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [Required]
        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [Required]
        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [Required]
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
