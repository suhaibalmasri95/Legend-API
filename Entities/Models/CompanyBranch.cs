using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CompanyBranch : CompanyDepCommon , ICompanyID
    {
        [JsonProperty(PropertyName = "ST_CTY_ID")]
        public long ST_CTY_ID { get; set; }
        [JsonProperty(PropertyName = "ST_COM_ID")]
        public long ST_COM_ID { get; set; }
    }
}
