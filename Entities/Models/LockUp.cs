using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class LockUp : Common
    {
        public LockUp ()
        {
            CREATION_DATE = DateTime.Now;
            MODIFICATION_DATE = DateTime.Now;
        }
        public long MAJOR_CODE { get; set; }

        public long MINOR_CODE { get; set; }

        public int? ST_LOCKUP_ID { get; set; }

        public string CREATED_BY { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFICATION_DATE { get; set; }
        public int? LOCKUP_TYPE { get; set; }
        public string REF_NO { get; set; }

    }
}
