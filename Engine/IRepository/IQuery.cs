using Engine.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.IRepository
{
    public interface IQuery
    {

        Task<IList> GetAllObjects(string SPName, OracleDynamicParameters Params);

       

    }
}
