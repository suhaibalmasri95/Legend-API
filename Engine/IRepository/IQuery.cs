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
        Task<IList> LoadCountries(Int64? countryId, Int64? langId);
        Task<IList> LoadCities(long? cityId, long? countryId, long? langId);
        Task<IList> LoadAreas(Int64? areaId, Int64? cityId, Int64? countryId, Int64? langId);
        Task<IList> LoadCurrencies(string CurrencyCode, Int64? langId = 1);
        Task<IList> LoadLockUps(long? ID, long? MajorCode, long? MinorCode, long? languageID = 1);
        Task<IList> LoadLockUpsMinorCode(long? ID, long? MajorCode, long? MinorCode, long? languageID = 1);
        Task<IList> LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCore, long? languageID = 1);
        Task<IList> LoadBanks(long? ID, long? languageID = 1);

        Task<IList> LoadBankBranches(long? ID, long? BankId, long? languageID = 1);
    }
}
