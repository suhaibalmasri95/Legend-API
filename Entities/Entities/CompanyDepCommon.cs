using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class CompanyDepCommon : CompanyCommon, IPhoning, IFax, ICurrencyCode, ICompanyCommon
    {
        [JsonProperty(PropertyName = "FAX")]
        public string FAX { get; set; }
        [JsonProperty(PropertyName = "PHONE")]
        public string PHONE { get; set; }

        [JsonProperty(PropertyName = "ADDRESS2")]
        public string ADDRESS2 { get; set; }

        [JsonProperty(PropertyName = "CODE")]
        public string CODE { get; set; }
        [JsonProperty(PropertyName = "ST_CUR_CODE")]
        public string ST_CUR_CODE { get; set; }
        [JsonProperty(PropertyName = "COUNTRY_CODE")]
        public string COUNTRY_CODE { get; set; }
        [JsonProperty(PropertyName = "ST_CNT_ID")]
        public long ST_CNT_ID { get; set; }
    }
}
