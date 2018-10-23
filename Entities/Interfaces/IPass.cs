using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IPass
    {
        Int32 PASS_MLENGHT { get; set; }
        Int32 PASS_MUPPER {get;set;}
        Int32 PASS_MLOWER { get; set; }
        Int32 PASS_MDIGITS { get; set; }
        Int32 PASS_MSPECIAL { get; set; }
        Int32 PASS_EXPIRY_PERIOD { get; set; }
        Int32 PASS_LOGATTEMPTS { get; set; }
        Int32 PASS_REPEAT { get; set; }
    }
}
