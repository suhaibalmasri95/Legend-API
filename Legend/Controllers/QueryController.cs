using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public class QueryController : ControllerBase
    {

        private IQuery _queryRepository;
        public QueryController(IQuery repository)
        {
            _queryRepository = repository;
        }

        [HttpGet]
        [Route("LoadCountries")]
        public async Task<List<Country>> LoadCountries(Int64? countryId, Int64? langId)
        {


           var result = await _queryRepository.LoadCountries(countryId, langId);

            return result;
        }




        [HttpGet]
        [Route("LoadCities")]
        public async Task<List<City>> LoadCities(long? cityId, long? countryId, long? langId)
        {

            var result = await _queryRepository.LoadCities(cityId, countryId, langId);
  
            return result;
        }
     
    


        [HttpGet]
        [Route("LoadAreas")]
        public async Task<List<Area>> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId)
        {

           var result = await _queryRepository.LoadAreas(areaId , cityId,countryId,langId);

            return result;
        }



        [HttpGet]
        [Route("LoadCurrencies")]
        public async Task<List<Currency>> LoadCurrencies(string CurrencyCode, Int64? langId=1)
        {

            var result = await _queryRepository.LoadCurrencies(CurrencyCode, langId);

            return result;
        }




        [HttpGet]
        [Route("LoadLockUps")]
        public async Task<List<LockUp>> LoadLockUps(long? ID, long? MajorCode, long? MinorCode, long? languageID = 1)
        {



           var result = await _queryRepository.LoadLockUps(ID, MajorCode, MinorCode, languageID);
            return result;
        }

        [HttpGet]
        [Route("LoadLockUpStatus")]
        public async Task<List<LockUp>> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCode, long? languageID )
        {


          var result = await _queryRepository.LoadLockUpStatus(ID, MajorCode, MinorCode, languageID);
      
            return result;
        }

        [HttpGet]
        [Route("LoadLockUpsMinorCode")]
        public async Task<List<LockUp>> LoadLockUpsMinorCode(long? ID, long? MajorCode, long? MinorCode, long? languageID)
        {


            List<LockUp> result = await  _queryRepository.LoadLockUpsMinorCode(ID, MajorCode, MinorCode, languageID);

            return result;
        }


        [HttpGet]
        [Route("LoadBanks")]
        public async Task<List<Bank>> LoadBanks(long? ID, long? languageID = 1)
        {

            var result = await _queryRepository.LoadBanks(ID, languageID);
      
            return result;
        }
        [HttpGet]
        [Route("LoadBankBranches")]
        public async Task<List<BankBranches>> LoadCompanyDepartment(long? ID, long? BankId, long? languageID = 1)
        {

            var result = await _queryRepository.LoadBankBranches(ID, BankId, languageID);

            return result;
        }
        [HttpGet]
        [Route("LoadCompanies")]
        public async Task<List<Company>> LoadCompanies(long? ID,   long? languageID = 1)
        {

           var result = await _queryRepository.LoadCompaniesAsync(ID,  languageID);
     
            return result;
        }
        [HttpGet]
        [Route("LoadCompanyBranches")]
        public async Task<List<CompanyBranch>> LoadCompanyBranches(long? ID, long? CompanyId, long? languageID = 1)
        {

            var result = await _queryRepository.LoadCompanyBranches(ID, CompanyId, languageID);

            return result;
        }
      
        [HttpGet]
        [Route("LoadCompanyDepartments")]
        public async Task<List<Department>> LoadCompanyDepartments(long? ID, long? CompanyId, long? languageID = 1)
        {

            var result = await _queryRepository.LoadCompanyDepartments(ID, CompanyId, languageID);

            return result;
        }
    }
}