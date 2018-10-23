using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
   public interface ICompanyCommon : ICountryID
    {
       string ST_CUR_CODE { get; set; }
        string  COUNTRY_CODE { get; set; }
    }
}
