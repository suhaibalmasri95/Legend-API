using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Engine.Common;
using Engine.IRepository;
using Engine.SPName;
using Engine.SPParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Legend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {

        private IQuery _queryRepository;
        public QueryController(IQuery repository)
        {
            _queryRepository = repository;
        }

        [HttpGet]
        [Route("LoadCountries")]
        public async Task<ActionResult> LoadCountries(Int64? countryId, Int64? langId)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_COUNTRY, dyParam);

            return Ok(result);
        }




        [HttpGet]
        [Route("LoadCities")]
        public async Task<ActionResult> LoadCities(long? cityId, long? countryId, long? langId)
        {


            var dyParam = new OracleDynamicParameters();
          
            dyParam.Add("IN_ID", OracleDbType.Int64,  ParameterDirection.Input , (object)cityId ?? DBNull.Value);
            dyParam.Add("IN_ST_CNT_ID", OracleDbType.Int64,ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add("IN_LANG", OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add("IN_REF_SELECT", OracleDbType.RefCursor, ParameterDirection.Output);

            var result = await _queryRepository.GetAllObjects("DBPK_ORG.LOAD_ST_CITIES", dyParam);
  

            
         


        

            return Ok(result);
        }



        [HttpGet]
        [Route("LoadAreas")]
        public async Task<ActionResult> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)areaId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countryId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cityId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_AREA, dyParam);

            return Ok(result);
        }



        [HttpGet]
        [Route("LoadCurrencies")]
        public async Task<ActionResult> LoadCurrencies(string CurrencyCode, Int64? langId=1)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input,  (object)CurrencyCode ?? DBNull.Value,30 );
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal,  ParameterDirection.Input , (object)langId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_CURRENCY, dyParam);

            return Ok(result);
        }




        [HttpGet]
        [Route("LoadLockUps")]
        public async Task<ActionResult> LoadLockUps(long? ID, long? MajorCode, long? MinorCore, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal,ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCore ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal,  ParameterDirection.Input , (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_LOCKUPS, dyParam);
            return Ok(result);
        }

        [HttpGet]
        [Route("LoadLockUpStatus")]
        public async Task<ActionResult> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCore, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCore ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_LOCKUPS, dyParam);
            result.RemoveAt(0);
            return Ok(result);
        }



        [HttpGet]
        [Route("LoadBanks")]
        public async Task<ActionResult> LoadBanks(long? ID, long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);

            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_BANCK, dyParam);
      
            return Ok(result);
        }
        [HttpGet]
        [Route("LoadBankBranches")]
        public async Task<ActionResult> LoadBankBranches(long? ID, long? BankId,  long? languageID = 1)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_BANK_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)BankId ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)languageID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = await _queryRepository.GetAllObjects(SPName.SP_LOAD_BANCK_BRANCH, dyParam);
     
            return Ok(result);
        }
    }
}