using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Base : Common, ILockUpStatus , IReference, IStatusDate
    {
        public Base ()
        {
            STATUS_DATE = DateTime.Now;
        }
        public long LOC_STATUS { get; set; }
        public string REFERNCE_NO { get; set; }
        public DateTime STATUS_DATE { get; set; }
    }
}
