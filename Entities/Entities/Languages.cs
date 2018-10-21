using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Languages : ILanguages
    {
        [JsonProperty(PropertyName = "NAME")]
        public string NAME { get; set; }
        [JsonProperty(PropertyName = "NAME2")]
        public string NAME2 { get; set; }
    }
}
