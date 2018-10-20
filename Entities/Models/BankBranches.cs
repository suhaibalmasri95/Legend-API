using Entities.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class BankBranches : Bank , IBankID, ICityID, ICountryID
    {
        public long ST_BNK_ID { get; set; }
        public long ST_CITY_ID { get; set; }
        public long ST_CNT_ID { get; set; }
    }
}
