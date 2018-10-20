using Dapper;
using Engine.Common;
using Engine.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Repository
{
    public class Query : IQuery
    {
        IConfiguration configuration;
        public Query(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<IList> GetAllObjects(string SPName, OracleDynamicParameters Params)
        {
            IList result = null;
            try
            {
                var connection = new DbConnection().GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();}

                if (connection.State == ConnectionState.Open)
                {
                    result = await SqlMapper.QueryAsync(connection, SPName, param: Params, commandType: CommandType.StoredProcedure) as IList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
