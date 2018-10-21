using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
   public class City : Base , ICountryID
    {
        [JsonProperty(PropertyName = "ST_CNT_ID")]
        public Int64 ST_CNT_ID { get; set; }
}
}
