using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Status : IStatusDate
    {
        [JsonProperty(PropertyName = "LOC_STATUS")]
        public long LOC_STATUS { get; set; }
        [JsonProperty(PropertyName = "STATUS_DATE")]
        public DateTime STATUS_DATE { get; set; }
    }
}
