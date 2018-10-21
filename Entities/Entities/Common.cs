using Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Common : Languages, IBase
    {
        [JsonProperty(PropertyName = "ID")]
        public long ID { get; set; }
    }
}
