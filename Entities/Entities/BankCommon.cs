using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class BankCommon : CommonCurBank, IPhoneCode, IPhoning , IBase
    {
        public string PHONE { get; set; }
        public string PHONE_CODE { get; set; }
        public long ID { get; set; }
    }
}
