using Engine.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.IRepository
{
    public interface IUpdate
    {

        Task<int> UpdateObjectAsync(string SPName, OracleDynamicParameters Params);
    }
}
