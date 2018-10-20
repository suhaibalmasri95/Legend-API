using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Status : IStatusDate
    {
        public long LOC_STATUS { get; set; }
        public DateTime STATUS_DATE { get; set; }
    }
}
