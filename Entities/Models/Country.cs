
using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
   public class Country : Base, IPhoneCode
    {
        [JsonProperty(PropertyName = "ST_CUR_CODE")]
        public string ST_CUR_CODE { get; set; }
        [JsonProperty(PropertyName = "PHONE_CODE")]
        public string PHONE_CODE { get; set; }
        [JsonProperty(PropertyName = "NATIONALITY")]
        public string NATIONALITY { get; set; }
        [JsonProperty(PropertyName = "FLAG")]
        public string FLAG{ get; set; }
    }
}
