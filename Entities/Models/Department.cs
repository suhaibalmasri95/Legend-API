using Entities.Entities;
using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Department : CompanyCommon, ICompanyID
    {
        [JsonProperty(PropertyName = "ST_COM_ID")]
        public long ST_COM_ID { get; set; }
    }
}
