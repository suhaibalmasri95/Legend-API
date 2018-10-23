using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Company : CompanyDepCommon, IPass , IMobile , IAdditionalInfo, ILogo
    {
        [JsonProperty(PropertyName = "MOBILE")]
        public string MOBILE { get; set; }
        [JsonProperty(PropertyName = "WEBSITE")]
        public string WEBSITE { get; set; }
        [JsonProperty(PropertyName = "CONTACT_PERSON")]
        public string CONTACT_PERSON { get; set; }
        public int PASS_MLENGHT { get; set; }
        [JsonProperty(PropertyName = "PASS_MUPPER")]
        public int PASS_MUPPER { get; set; }
        [JsonProperty(PropertyName = "PASS_MLOWER")]
        public int PASS_MLOWER { get; set; }
        [JsonProperty(PropertyName = "PASS_MDIGITS")]
        public int PASS_MDIGITS { get; set; }
        [JsonProperty(PropertyName = "PASS_MSPECIAL")]
        public int PASS_MSPECIAL { get; set; }
        [JsonProperty(PropertyName = "PASS_EXPIRY_PERIOD")]
        public int PASS_EXPIRY_PERIOD { get; set; }
        [JsonProperty(PropertyName = "PASS_LOGATTEMPTS")]
        public int PASS_LOGATTEMPTS { get; set; }
        [JsonProperty(PropertyName = "PASS_REPEAT")]
        public int PASS_REPEAT { get; set; }
        [JsonProperty(PropertyName = "LOGO")]
        public string LOGO { get; set ; }
    }
}
