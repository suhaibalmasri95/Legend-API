using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
   public class Area : City
    {

        [JsonProperty(PropertyName = "ST_CTY_ID")]
        public Int64 ST_CTY_ID { get; set; }

    }
}
