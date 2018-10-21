using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Currency : CommonCurBank , IStatusDate
    {
        public Currency (){
            STATUS_DATE = DateTime.Now;
        }
        [JsonProperty(PropertyName = "DECIMAL_PLACES")]
        public Int64 DECIMAL_PLACES { get; set; }
        [JsonProperty(PropertyName = "STATUS")]
        public Int64 STATUS { get; set; }
        [JsonProperty(PropertyName = "SIGN")]
        public string SIGN { get; set; }
        [JsonProperty(PropertyName = "IS_DELETED")]
        public Int64 IS_DELETED { get; set; }
        [JsonProperty(PropertyName = "STATUS_DATE")]
        public DateTime STATUS_DATE { get;set;}
        [JsonProperty(PropertyName = "FRACT_NAME")]
        public string FRACT_NAME { get; set; }
        [JsonProperty(PropertyName = "FRACT_NAME2")]
        public string FRACT_NAME2 { get; set; }
    }
}
