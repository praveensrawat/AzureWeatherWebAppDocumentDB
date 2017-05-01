using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//P.R Add dependency
using Newtonsoft.Json;


namespace weather.Models
{
    public class Weather
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "temp")]
        public string Temperature { get; set; }

        [JsonProperty(PropertyName = "isSevere")]
        public bool Severe { get; set; }

    }
}
