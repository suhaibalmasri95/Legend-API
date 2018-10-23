using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class CreateController : ControllerBase
    {
        private ICreate _createRepository;
        public CreateController(ICreate repository)
        {
            _createRepository = repository;
        }

        [HttpPost]
        [Route("CreateCountry")]
        public async Task<int> CreateCountry([FromBody]Country country)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NAME2 ?? DBNull.Value, 500 );
            dyParam.Add(Params.PARAMETER_COUNTRY_NATIONALITY, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.NATIONALITY ?? DBNull.Value ,100);
            dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.ST_CUR_CODE ?? DBNull.Value,30 );
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.REFERNCE_NO ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)country.LOC_STATUS ?? DBNull.Value );
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input,(object)country.STATUS_DATE ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.PHONE_CODE ?? DBNull.Value, 50 );
            dyParam.Add(Params.PARAMETER_COUNTRY_FLAG, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.FLAG ?? DBNull.Value,500);

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSER_COUNTRY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.Created);
            else
                return Convert.ToInt32(HttpStatusCode.ExpectationFailed);
        }

        [HttpPost]
        [Route("AddCountryFlag")]
        public async Task<IActionResult> AddCountryFlag([FromForm] Photo flag)
        {

            string pathToReturn = "";

            var file = flag.File;


            if (file != null)
            {
                Random rand = new Random();
                int guid = rand.Next();
                string ext = Path.GetExtension(file.FileName);
                string imagepath = Path.GetFileNameWithoutExtension(file.FileName) + guid.ToString() + ext.ToString();

                var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "wwwroot/Flags",
                       imagepath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


                pathToReturn = Request.Scheme + "://" + Request.Host.Value + "/" + "Flags/" + imagepath;

            }
            return Ok(pathToReturn);


        }




        [HttpPost]
        [Route("CreateCity")]
        public async Task<int> CreateCity([FromBody]City city)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.NAME ?? DBNull.Value, 500 );
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.NAME2 ?? DBNull.Value,  500);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input , (object)city.REFERNCE_NO ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input,(object)city.LOC_STATUS ?? DBNull.Value );
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input,(object)city.STATUS_DATE ?? DBNull.Value);
         
    

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_CITY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.Created);
            else
                return Convert.ToInt32(HttpStatusCode.ExpectationFailed);
        }



        [HttpPost]
        [Route("CreateArea")]
        public async Task<int> CreateArea([FromBody]Area area)
        {
            var dyParam = new OracleDynamicParameters();

         
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2,   ParameterDirection.Input,(object)area.NAME ?? DBNull.Value,500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input , (object)area.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input,(object)area.ST_CTY_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input , (object)area.REFERNCE_NO ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input,(object)area.LOC_STATUS ?? DBNull.Value );
            dyParam.Add(Params.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input,(object)area.STATUS_DATE ?? DBNull.Value);

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_AREA, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.Created);
            else
                return Convert.ToInt32(HttpStatusCode.ExpectationFailed);
        }



        [HttpPost]
        [Route("CreateBank")]
        public async Task<int> CreateBank([FromBody]Bank bank)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.CODE ?? DBNull.Value, 100);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.PHONE_CODE ?? DBNull.Value, 50 );
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.PHONE ?? DBNull.Value , 50);

           


            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_BANCK, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.Created);
            else
                return Convert.ToInt32(HttpStatusCode.ExpectationFailed);
        }


        [HttpPost]
        [Route("CreateBankBranch")]
        public async Task<int> CreateBankBranch([FromBody]BankBranches bankBranches)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.CODE ?? DBNull.Value, 100);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.PHONE_CODE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranches.PHONE ?? DBNull.Value, 50);
            dyParam.Add(Params.PARAMETER_BANK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_BNK_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_CITY_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranches.ST_CNT_ID ?? DBNull.Value);
          

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_BANCK_BRANCH, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.Created);
            else
                return Convert.ToInt32(HttpStatusCode.ExpectationFailed);
        }


        [HttpPost]
        [Route("CreateCurrency")]
        public async Task<int> CreateCurrency([FromBody]Currency currency)
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

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_CURRENCY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }


        [HttpPost]
        [Route("CreateLockUp")]
        public async Task<int> CreateLockUp([FromBody]LockUp lockup)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
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
            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_LOCKUPS, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }


        [HttpPost]
        [Route("CreateCompany")]
        public async Task<int> CreateCompany([FromBody]Company company)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.PHONE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_COUNTRY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.COUNTRY_CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.MOBILE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_FAX, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.FAX ?? DBNull.Value,30);
            dyParam.Add(Params.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Email ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_WEBSITE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.WEBSITE ?? DBNull.Value,30);
            dyParam.Add(Params.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.ADDRESS ?? DBNull.Value,30);
            dyParam.Add(Params.PARAMETER_ADDRESS2, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.ADDRESS2 ?? DBNull.Value,30);
            dyParam.Add(Params.PARAMETER_CONTACT_PERSON, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.CONTACT_PERSON ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.ST_CUR_CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)company.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_LOGO, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.LOGO ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_PASS_MLENGHT, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_MLENGHT ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_MUPPER, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_MUPPER ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_MLOWER, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_MLOWER ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_MDIGITS, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_MDIGITS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_MSPECIAL, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_MSPECIAL ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_EXPIRY_PERIOD, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_EXPIRY_PERIOD ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_LOGATTEMPTS, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_LOGATTEMPTS ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_PASS_REPEAT, OracleDbType.Int32, ParameterDirection.Input, (object)company.PASS_REPEAT ?? DBNull.Value);
            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_COMPANY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpPost]
        [Route("CreateCompanyBranch")]
        public async Task<int> CreateCompanyBranch([FromBody]CompanyBranch companyBranch)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.CODE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.PHONE ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_FAX, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.FAX ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.ADDRESS ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_ADDRESS2, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.ADDRESS2 ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.ST_COM_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.ST_CTY_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.ST_CNT_ID ?? DBNull.Value);
            dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.ST_CUR_CODE ?? DBNull.Value, 30);
     
            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_COMPANY_BRANCH, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpPost]
        [Route("CreateCompanyDepartment")]
        public async Task<int> CreateCompanyDepartment([FromBody]Department department)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
            dyParam.Add(Params.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.NAME ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.NAME2 ?? DBNull.Value, 500);
            dyParam.Add(Params.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.ADDRESS ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.Email ?? DBNull.Value, 30);
            dyParam.Add(Params.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)department.ST_COM_ID ?? DBNull.Value, 30);
   

            int result = await _createRepository.CreateObjectAsync(SPName.SP_INSERT_COMPANY_DEPARTMENT, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }
    }
}
 