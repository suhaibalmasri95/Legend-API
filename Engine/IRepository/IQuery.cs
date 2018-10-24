using Engine.Common;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Engine.IRepository
{
    public interface IQuery
    {

        Task<IList> GetAllObjects(string SPName, OracleDynamicParameters Params);
        Task<List<DTO>> GetAllObjectsAsEntityAsync<DTO>(string SPName, OracleDynamicParameters Params) where DTO : class;
        Task<List<Country>> LoadCountries(Int64? countryId, Int64? langId);
        Task<List<City>> LoadCities(long? cityId, long? countryId, long? langId);
        Task<List<Area>> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId);
        Task<List<Currency>> LoadCurrencies(string CurrencyCode, Int64? langId = 1);
        Task<List<LockUp>> LoadLockUps(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1);
        Task<List<LockUp>> LoadLockUpsMinorCode(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1);
        Task<List<LockUp>> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1);
        Task<List<Bank>> LoadBanks(long? ID, long? languageID = 1);

        Task<List<BankBranches>> LoadBankBranches(long? ID, long? BankId, long? languageID = 1);
        Task<List<Company>> LoadCompaniesAsync(long? ID, long? languageID = 1);
        Task<List<CompanyBranch>> LoadCompanyBranches(long? ID, long? companyID, long? languageID = 1);
        Task<List<Department>> LoadCompanyDepartments(long? ID, long? companyID, long? languageID = 1);

    }
}
