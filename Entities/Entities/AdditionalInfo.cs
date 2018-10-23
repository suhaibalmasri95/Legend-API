using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class AdditionalInfo : IAdditionalInfo
    {
        public string WEBSITE { get; set; }
        public string CONTACT_PERSON { get; set; }
    }
}
