using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public abstract class BaseEntity
    {
        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public DateTime Created { get; set; }

        [JsonProperty]
        public DateTime Edited { get; set; }

        protected abstract string EntryPath { get; }

        public string GetPath()
        {
            return EntryPath;
        }
    }
}