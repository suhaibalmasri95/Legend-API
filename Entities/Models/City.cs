using Entities.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
   public class City : Base , ICountryID
    {

        public Int64 ST_CNT_ID { get; set; }
}
}
