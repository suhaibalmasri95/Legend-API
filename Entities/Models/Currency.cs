using Entities.Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Currency : CommonCurBank , IStatusDate
    {
        public Currency (){
            STATUS_DATE = DateTime.Now;
        }
        public Int64 DECIMAL_PLACES { get; set; }
        public Int64 STATUS { get; set; }
        public string SIGN { get; set; }
        public Int64 IS_DELETED { get; set; }
        public DateTime STATUS_DATE { get;set;}
        public string FRACT_NAME { get; set; }
      
        public string FRACT_NAME2 { get; set; }
    }
}
