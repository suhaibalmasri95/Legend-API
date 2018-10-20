using Engine.Common;
using Engine.IRepository;
using System;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Engine.Repository
{
    public class Create : ICreate
    {

        IConfiguration configuration;
        public Create(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<int> CreateObjectAsync(string SPName, OracleDynamicParameters Params)
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
