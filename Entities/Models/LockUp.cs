using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class LockUp : Common
    {
        public LockUp ()
        {
            CREATION_DATE = DateTime.Now;
            MODIFICATION_DATE = DateTime.Now;
        }
        [JsonProperty(PropertyName = "MAJOR_CODE")]
        public long MAJOR_CODE { get; set; }
        [JsonProperty(PropertyName = "MINOR_CODE")]
        public long MINOR_CODE { get; set; }
        [JsonProperty(PropertyName = "ST_LOCKUP_ID")]
        public int? ST_LOCKUP_ID { get; set; }
        [JsonProperty(PropertyName = "CREATED_BY")]
        public string CREATED_BY { get; set; }
        [JsonProperty(PropertyName = "CREATION_DATE")]
        public DateTime CREATION_DATE { get; set; }
        [JsonProperty(PropertyName = "MODIFIED_BY")]
        public string MODIFIED_BY { get; set; }
        [JsonProperty(PropertyName = "MODIFICATION_DATE")]
        public DateTime MODIFICATION_DATE { get; set; }
        [JsonProperty(PropertyName = "LOCKUP_TYPE")]
        public int? LOCKUP_TYPE { get; set; }
        [JsonProperty(PropertyName = "REF_NO")]
        public string REF_NO { get; set; }

    }
}
