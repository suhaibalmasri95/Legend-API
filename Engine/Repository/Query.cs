using Dapper;
using Engine.Common;
using Engine.IRepository;
using Engine.SPParams;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Engine.Helpers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

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

      
        public async Task<List<DTO>> GetAllObjectsAsEntityAsync<DTO>(string SPName, OracleDynamicParameters Params) where DTO : class
        {
            List<DTO> result = null;
            try
            {
                var connection = new DbConnection().GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (connection.State == ConnectionState.Open)
                {
                    result = await SqlMapper.QueryAsync<DTO>(connection, SPName, param: Params, commandType: CommandType.StoredProcedure) as List<DTO>;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public async Task<List<Country>> LoadCountries(Int64? countryId, Int64? langId)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Country>(SPName.SPName.SP_LOAD_COUNTRY, dyParam);

            return result;
        }


      
        public async Task<List<City>> LoadCities(long? cityId, long? countryId, long? langId)
        {


            var dyParam = new OracleDynamicParameters();

            dyParam.Add("IN_ID", OracleDbType.Int64, ParameterDirection.Input, (object)cityId ?? DBNull.Value);
            dyParam.Add("IN_ST_CNT_ID", OracleDbType.Int64, ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add("IN_LANG", OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add("IN_REF_SELECT", OracleDbType.RefCursor, ParameterDirection.Output);

            var result = await GetAllObjectsAsEntityAsync<City>(SPName.SPName.SP_LOAD_CITY, dyParam);

            return result;
        }

       



        public async Task<List<Area>> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)areaId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cityId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Area>(SPName.SPName.SP_LOAD_AREA, dyParam);

            return result;
        }



        public async Task<List<Currency>> LoadCurrencies(string CurrencyCode, Int64? langId = 1)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)CurrencyCode ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Currency>(SPName.SPName.SP_LOAD_CURRENCY, dyParam);

            return result;
        }


       
        public async Task<List<LockUp>> LoadLockUps(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_LOCKUP_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LockupParentID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            
            
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<LockUp>(SPName.SPName.SP_LOAD_LOCKUPS, dyParam);
            return result;
        }

       
        public async Task<List<LockUp>> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_LOCKUP_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LockupParentID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


           var result = await GetAllObjectsAsEntityAsync<LockUp>(SPName.SPName.SP_LOAD_LOCKUPS, dyParam);
           // result.RemoveAt(0);
            return result;
        }


        public async Task<List<LockUp>> LoadLockUpsMinorCode(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1)
        {
            List<LockUp> minorCodes = new List<LockUp>();
            List<LockUp> minorCodesToReturn = new List<LockUp>();
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_LOCKUP_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LockupParentID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);



            minorCodes =await GetAllObjectsAsEntityAsync<LockUp>(SPName.SPName.SP_LOAD_LOCKUPS, dyParam);

            foreach (var item in minorCodes)
            {
                if (item.MINOR_CODE != 0)
                    minorCodesToReturn.Add(item);

            }




            return minorCodesToReturn;
        }



        public async Task<List<Bank>> LoadBanks(long? ID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);

            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Bank>(SPName.SPName.SP_LOAD_BANCK, dyParam);

            return result ;
        }

        public async Task<List<BankBranches>> LoadBankBranches(long? ID, long? BankId, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_BANK_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)BankId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<BankBranches>(SPName.SPName.SP_LOAD_BANCK_BRANCH, dyParam); ;

            return result;
        }

        public async Task<List<Company>> LoadCompaniesAsync(long? ID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
       
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Company>(SPName.SPName.SP_LOAD_COMPANY, dyParam); 

            return result;
        }

        public async Task<List<CompanyBranch>> LoadCompanyBranches(long? ID, long? companyID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COMPANY_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)companyID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<CompanyBranch>(SPName.SPName.SP_LOAD_BANCK_BRANCH, dyParam); ;

            return result;
        }

        public async Task<List<Department>> LoadCompanyDepartments(long? ID, long? companyID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COMPANY_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)companyID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await GetAllObjectsAsEntityAsync<Department>(SPName.SPName.SP_LOAD_BANCK_BRANCH, dyParam); ;

            return result;
        }
    }
}
