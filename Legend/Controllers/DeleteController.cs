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
    public class DeleteController : ControllerBase
    {
        private IDelete _DeleteRepository;
        public DeleteController(IDelete repository)
        {
            _DeleteRepository = repository;
        }

        [HttpDelete]
        [Route("DeleteCountry")]
        public async Task<int> DeleteCountry(int countryID)
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countryID ?? DBNull.Value);
     
            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COUNTRY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }
        [HttpDelete]
        [Route("DeleteCountries")]
        public async Task<int> DeleteCountries([FromBody]int[] countries)
        {
            int result = 0;
            int countryArrayLenght = countries.Length;
            for (int i = 0; i < countryArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)countries[i] ?? DBNull.Value);

                 result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COUNTRY, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
          

          
                return Convert.ToInt32(HttpStatusCode.OK);
 
               
        }




        [HttpDelete]
        [Route("DeleteCity")]
        public async Task<int> DeleteCity(int cityID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cityID ?? DBNull.Value);
         

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_CITY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpDelete]
        [Route("DeleteCities")]
        public async Task<int> DeleteCities([FromBody]int[] cities)
        {
            int result = 0;
            int citiesArrayLenght = cities.Length;
            for (int i = 0; i < citiesArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cities[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_CITY, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }

            return Convert.ToInt32(HttpStatusCode.OK);


        }

        [HttpDelete]
        [Route("DeleteArea")]
        public async Task<int> DeleteArea(int areaID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)areaID ?? DBNull.Value);
          

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_AREA, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpDelete]
        [Route("DeleteAreas")]
        public async Task<int> DeleteAreas([FromBody]int[] areas)
        {
            int result = 0;
            int areasArrayLenght = areas.Length;
            for (int i = 0; i < areasArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)areas[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_AREA, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }

            return Convert.ToInt32(HttpStatusCode.OK);


        }

        [HttpDelete]
        [Route("DeleteBank")]
        public async Task<int> DeleteBank(int bankID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankID ?? DBNull.Value);
     


            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_BANCK, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }
        [HttpDelete]
        [Route("DeleteBanks")]
        public async Task<int> DeleteBanks([FromBody]int[] banks)
        {
            int result = 0;
            int banksArrayLenght = banks.Length;
            for (int i = 0; i < banksArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)banks[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_BANCK, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }

            return Convert.ToInt32(HttpStatusCode.OK);


        }

        [HttpDelete]
        [Route("DeleteBankBranch")]
        public async Task<int> DeleteBankBranch(int bankBranchesID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranchesID ?? DBNull.Value);
          
            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_BANCK_BRANCH, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }
        [HttpDelete]
        [Route("DeleteBankBranchs")]
        public async Task<int> DeleteBankBranchs([FromBody]int[] bankbranches)
        {
            int result = 0;
            int bankbranchesArrayLenght = bankbranches.Length;
            for (int i = 0; i < bankbranchesArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankbranches[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_BANCK_BRANCH, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }

            [HttpDelete]
             [Route("DeleteCurrency")]
             public async Task<int> DeleteCurrency(string currencyCode)
             {
                 var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currencyCode ?? DBNull.Value, 30);

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_CURRENCY, dyParam);

                  if (result == -1)
                    return Convert.ToInt32(HttpStatusCode.OK);
                else
                    return Convert.ToInt32(HttpStatusCode.NotModified);
             }


        [HttpDelete]
        [Route("DeleteCurrencies")]
        public async Task<int> DeleteCurrencies([FromBody]string[] currencies)
        {
            int result = 0;
            int currenciesArrayLenght = currencies.Length;
            for (int i = 0; i < currenciesArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currencies[i] ?? DBNull.Value, 30);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_CURRENCY, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }

        [HttpDelete]
             [Route("DeleteLockUp")]
             public async Task<int> DeleteLockUp( int lockupID)
             {
                 var dyParam = new OracleDynamicParameters();

                       dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockupID ?? DBNull.Value);
            
                 int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_LOCKUPS, dyParam);

                  if (result == -1)
                    return Convert.ToInt32(HttpStatusCode.OK);
                else
                    return Convert.ToInt32(HttpStatusCode.NotModified);
             }

        [HttpDelete]
        [Route("DeleteLockUps")]
        public async Task<int> DeleteLockUps([FromBody]int[] lockups)
        {
            int result = 0;
            int lockupsArrayLenght = lockups.Length;
            for (int i = 0; i < lockupsArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockups[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_CURRENCY, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }

     

        [HttpDelete]
        [Route("DeleteCompany")]
        public async Task<int> DeleteCompany(int CountryID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CountryID ?? DBNull.Value);

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpDelete]
        [Route("DeleteCompanies")]
        public async Task<int> DeleteCompanies([FromBody]int[] Coutnries)
        {
            int result = 0;
            int CoutnriesArrayLenght = Coutnries.Length;
            for (int i = 0; i < CoutnriesArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Coutnries[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }

        [HttpDelete]
        [Route("DeleteCompanyBranch")]
        public async Task<int> DeleteCompanyBranch(int BranchID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)BranchID ?? DBNull.Value);

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY_BRANCH, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpDelete]
        [Route("DeleteCompanyBranches")]
        public async Task<int> DeleteCompanyBranches([FromBody]int[] branches)
        {
            int result = 0;
            int branchesArrayLenght = branches.Length;
            for (int i = 0; i < branchesArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)branches[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY_BRANCH, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }


        [HttpDelete]
        [Route("DeleteCompanyDepartment")]
        public async Task<int> DeleteCompanyDepartment(int DepartmentID)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)DepartmentID ?? DBNull.Value);

            int result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY_DEPARTMENT, dyParam);

            if (result == -1)
                return Convert.ToInt32(HttpStatusCode.OK);
            else
                return Convert.ToInt32(HttpStatusCode.NotModified);
        }

        [HttpDelete]
        [Route("DeleteLockUps")]
        public async Task<int> DeleteCompanyDepartments([FromBody]int[] Departments)
        {
            int result = 0;
            int DepartmentsArrayLenght = Departments.Length;
            for (int i = 0; i < DepartmentsArrayLenght; i++)
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Departments[i] ?? DBNull.Value);

                result = await _DeleteRepository.DeleteObjectAsync(SPName.SP_DELETE_COMPANY_DEPARTMENT, dyParam);
                if (result != -1)
                    return Convert.ToInt32(HttpStatusCode.NotModified);
            }
            return Convert.ToInt32(HttpStatusCode.OK);


        }
    }
}