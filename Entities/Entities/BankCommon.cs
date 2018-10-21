using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class BankCommon : CommonCurBank, IPhoneCode, IPhoning , IBase
    {
        [JsonProperty(PropertyName = "PHONE")]
        public string PHONE { get; set; }
        [JsonProperty(PropertyName = "PHONE_CODE")]
        public string PHONE_CODE { get; set; }
        [JsonProperty(PropertyName = "PHONE_CODE")]
        public long ID { get; set; }
    }
}
