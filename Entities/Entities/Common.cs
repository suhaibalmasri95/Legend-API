using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Common : Languages, IBase
    {
        public long ID { get; set; }
    }
}
