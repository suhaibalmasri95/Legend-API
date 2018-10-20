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
        public async Task<IList> LoadCountries(Int64? countryId, Int64? langId)
        {


           var result = await _queryRepository.LoadCountries(countryId, langId);

            return result;
        }




        [HttpGet]
        [Route("LoadCities")]
        public async Task<IList> LoadCities(long? cityId, long? countryId, long? langId)
        {

            var result = await _queryRepository.LoadCities(cityId, countryId, langId);
  
            return result;
        }



        [HttpGet]
        [Route("LoadAreas")]
        public async Task<IList> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId)
        {

           var result = await _queryRepository.LoadAreas(areaId , cityId,countryId,langId);

            return result;
        }



        [HttpGet]
        [Route("LoadCurrencies")]
        public async Task<IList> LoadCurrencies(string CurrencyCode, Int64? langId=1)
        {

            var result = await _queryRepository.LoadCurrencies(CurrencyCode, langId);

            return result;
        }




        [HttpGet]
        [Route("LoadLockUps")]
        public async Task<IList> LoadLockUps(long? ID, long? MajorCode, long? MinorCore, long? languageID = 1)
        {



           var result = await _queryRepository.LoadLockUps(ID, MajorCode, MinorCore, languageID);
            return result;
        }

        [HttpGet]
        [Route("LoadLockUpStatus")]
        public async Task<IList> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCore, long? languageID = 1)
        {


          var result = await _queryRepository.LoadLockUpStatus(ID, MajorCode, MinorCore, languageID);
      
            return result;
        }



        [HttpGet]
        [Route("LoadBanks")]
        public async Task<IList> LoadBanks(long? ID, long? languageID = 1)
        {

            var result = await _queryRepository.LoadBanks(ID, languageID);
      
            return result;
        }
        [HttpGet]
        [Route("LoadBankBranches")]
        public async Task<IList> LoadBankBranches(long? ID, long? BankId,  long? languageID = 1)
        {

           var result = await _queryRepository.LoadBankBranches(ID, BankId, languageID);
     
            return result;
        }
    }
}