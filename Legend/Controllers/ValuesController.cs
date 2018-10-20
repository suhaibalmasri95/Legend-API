using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Engine.Common;
using Engine.IRepository;

using Engine.SPName;
using Engine.SPParams;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Legend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        private IQuery _queryRepository;
        public ValuesController(IQuery repository)
        {
            _queryRepository = repository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            /*var dyParam = new OracleDynamicParameters();
            dyParam.Add(Params.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, DBNull.Value);
            dyParam.Add(Params.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, DBNull.Value);
            dyParam.Add(Params.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);


            var result = _queryRepository.GetAllObjects(SPName.SP_LOAD_COUNTRY, dyParam , new DbConnection().GetConnection());

            return Ok(result);*/
           
            return Ok();
        
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
