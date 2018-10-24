using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class CompanyCommon : Languages, IBase  ,IAddress ,IEmail
    {
    
        [JsonProperty(PropertyName = "ID")]
        public long ID { get; set; }
        [JsonProperty(PropertyName = "ADDRESS")]
        public string ADDRESS { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string EMAIL { get; set; }
    }
}
