using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class CommonCurBank : Languages, ICurrencyCode
    {
        [JsonProperty(PropertyName = "CODE")]
        public string CODE { get; set; }
    }
}
