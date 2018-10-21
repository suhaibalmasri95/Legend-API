using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class BankBranches : Bank , IBankID, ICityID, ICountryID
    {
        [JsonProperty(PropertyName = "ST_BNK_ID")]
        public long ST_BNK_ID { get; set; }
        [JsonProperty(PropertyName = "ST_CITY_ID")]
        public long ST_CITY_ID { get; set; }
        [JsonProperty(PropertyName = "ST_CNT_ID")]
        public long ST_CNT_ID { get; set; }
    }
}
