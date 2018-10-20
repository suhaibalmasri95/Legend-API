using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Engine.Common;
using Engine.IRepository;
using Engine.SPName;
using Engine.SPParams;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Legend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private IUpdate _UpdateRepository;
        public UpdateController(IUpdate repository)
        {
            _UpdateRepository = repository;
        }


        [HttpPost]
        [Route("UpdateCountry")]
        public async Task<int> UpdateCountry([FromBody]Country country)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)country.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_COUNTRY_NATIONALITY, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NATIONALITY ?? DBNull.Value, 100);
            dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.ST_CUR_CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.REFERNCE_NO ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)country.LOC_STATUS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)country.STATUS_DATE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.PHONE_CODE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_COUNTRY_FLAG, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.FLAG ?? DBNull.Value, 500);

            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPADTE_COUNTRY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }





        [HttpPost]
        [Route("UpdateCity")]
        public async Task<int> UpdateCity([FromBody]City city)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.REFERNCE_NO ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)city.LOC_STATUS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)city.STATUS_DATE ?? DBNull.Value);



            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPADTE_CITY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }



        [HttpPost]
        [Route("UpdateArea")]
        public async Task<int> UpdateArea([FromBody]Area area)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.ST_CTY_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.REFERNCE_NO ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)area.LOC_STATUS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)area.STATUS_DATE ?? DBNull.Value);


            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPADTE_AREA, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }



        [HttpPost]
        [Route("UpdateBank")]
        public async Task<int> UpdateBank([FromBody]Bank bank)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bank.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.CODE ?? DBNull.Value, 100);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.PHONE_CODE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.PHONE ?? DBNull.Value, 50);




            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPADTE_BANCK, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }


        [HttpPost]
        [Route("UpdateBankBranch")]
        public async Task<int> UpdateBankBranch([FromBody]BankBranches bankBranches)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.CODE ?? DBNull.Value, 100);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.PHONE_CODE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.PHONE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_BANK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_BNK_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_CITY_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_CNT_ID ?? DBNull.Value);

            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPADTE_BANCK_BRANCH, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }


         [HttpPost]
         [Route("UpdateCurrency")]
         public async Task<int> UpdateCurrency([FromBody]Currency currency)
         {
             var dyParam = new OracleDynamicParameters();


            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_DECIMAL_PLACES, OracleDbType.Int32, ParameterDirection.Input, (object)currency.DECIMAL_PLACES ?? DBNull.Value, 5);
            dyParam.Add(Params.PARAMETER_SIGN, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.SIGN ?? DBNull.Value, 200);
            dyParam.Add(Params.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)currency.STATUS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)currency.STATUS_DATE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_FRACT, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FRACT_NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_FRACT2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FRACT_NAME2 ?? DBNull.Value, 500);

            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPDATE_CURRENCY, dyParam);

              if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
         }


         [HttpPost]
         [Route("UpdateLockUp")]
         public async Task<int> UpdateLockUp([FromBody]LockUp lockup)
         {
             var dyParam = new OracleDynamicParameters();

                   dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MAJOR_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.MAJOR_CODE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_MINOR_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.MINOR_CODE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.CREATED_BY ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)lockup.CREATION_DATE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.MODIFIED_BY ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)lockup.MODIFICATION_DATE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_ST_LOCKUP_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.ST_LOCKUP_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LOCKUP_TYPE, OracleDbType.Int32, ParameterDirection.Input, (object)lockup.LOCKUP_TYPE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.REF_NO ?? DBNull.Value, 100);
            int result = await _UpdateRepository.UpdateObjectAsync(SPName.SP_UPDATE_LOCKUPS, dyParam);

              if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
         }
    }
}