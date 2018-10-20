
using Entities.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
   public class Country : Base, IPhoneCode
    {
       
        public string ST_CUR_CODE { get; set; }

        public string PHONE_CODE { get; set; }
        public string NATIONALITY { get; set; }
        public string FLAG{ get; set; }
    }
}
