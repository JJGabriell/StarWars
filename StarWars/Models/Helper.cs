using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Helper<T> where T : BaseEntity
    {
        [JsonProperty]
        public ICollection<T> Results { get; set; }

        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public string Next { get; set; }

        [JsonProperty]
        public string Previous { get; set; }
    }

}