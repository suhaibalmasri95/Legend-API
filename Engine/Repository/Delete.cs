using Dapper;
using Engine.Common;
using Engine.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Repository
{
    public class Delete : IDelete
    {
        IConfiguration configuration;
        public Delete(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<int> DeleteObjectAsync(string SPName, OracleDynamicParameters Params)
        {
            int result = 0;
            try
            {
                var connection = new DbConnection().GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (connection.State == ConnectionState.Open)
                {
                    result = await SqlMapper.ExecuteAsync(connection, SPName, param: Params, commandType: CommandType.StoredProcedure);

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
