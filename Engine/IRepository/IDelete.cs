using Engine.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.IRepository
{
    public interface IDelete
    {

        Task<int> DeleteObjectAsync(string SPName, OracleDynamicParameters Params);

    }
}
