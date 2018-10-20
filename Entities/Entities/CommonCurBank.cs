using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class CommonCurBank : Languages, ICurrencyCode
    {
        public string CODE { get; set; }
    }
}
