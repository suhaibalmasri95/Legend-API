using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Helpers;
using Engine.IRepository;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Legend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitesController : ControllerBase
    {
        private IQuery _queryRepository;
        public UtilitesController(IQuery repository)
        {
            _queryRepository = repository;
        }
        [HttpGet]
        [Route("ExportToPdf")]
        public async Task<IActionResult> ExportToPdfAsync(string fileName, string Type)
        {
           


            DataTable dt = new DataTable();
            Random rand = new Random();
            int guid = rand.Next();
            fileName += guid.ToString() + ".pdf";
            if (Type.ToLower() == "country")
            {
                List<Country> countries = await _queryRepository.LoadCountries(null, null);
          

                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                List<City> cities = await _queryRepository.LoadCities(null, null,null);
           
                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                List<Area> areas = await _queryRepository.LoadAreas(null, null, null, null);

           

                dt = Utilities.ToDataTable(areas);
             

            }
            else if (Type.ToLower() == "lockup")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, null, null);
                

                dt = Utilities.ToDataTable(LockUps);
           

            }
            else if (Type.ToLower() == "majorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, 0, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "minorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUpsMinorCode(null, null, null, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "bank")
            {
                List<Bank> banks = await _queryRepository.LoadBanks(null, null);

                

                dt = Utilities.ToDataTable(banks);
        

            }
            else if (Type.ToLower() == "bankbranches")
            {
                List<BankBranches> bankBranches = await _queryRepository.LoadBankBranches(null, null,null);

            

                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                List<Currency> currencies = await _queryRepository.LoadCurrencies(null, null);

                

                dt = Utilities.ToDataTable(currencies);
            

            }
            else
            {

                return Ok(new { StatusCode = "Code Not Available" });
            }
            var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Documents",
                     fileName);

            Utilities.ExportDataTableToPdf(dt, path, fileName);


            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Utilities.GetContentType(path), Path.GetFileName(path));

        }



        [HttpPost]
        [Route("ExportData")]
        public IActionResult ExportData([FromBody] IEnumerable<object> Entity)
        {


            Type t = Entity.GetType();




            return Ok( Entity);
        }


        [HttpGet]
        [Route("ExportToExcel")]
        public async Task<IActionResult> ExportToExcelAsync(string fileName, string Type)
        {
         


            DataTable dt = new DataTable();
            Random rand = new Random();
            int guid = rand.Next();
            string file = fileName;
            fileName += guid.ToString() + ".xlsx";
            if (Type.ToLower() == "country")
            {
                List<Country> countries = await _queryRepository.LoadCountries(null, null);


                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                List<City> cities = await _queryRepository.LoadCities(null, null, null);

                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                List<Area> areas = await _queryRepository.LoadAreas(null, null, null, null);



                dt = Utilities.ToDataTable(areas);


            }
            else if (Type.ToLower() == "lockup")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, null, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "majorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, 0, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "minorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUpsMinorCode(null, null, null, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "bank")
            {
                List<Bank> banks = await _queryRepository.LoadBanks(null, null);



                dt = Utilities.ToDataTable(banks);


            }
            else if (Type.ToLower() == "bankbranches")
            {
                List<BankBranches> bankBranches = await _queryRepository.LoadBankBranches(null, null, null);



                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                List<Currency> currencies = await _queryRepository.LoadCurrencies(null, null);



                dt = Utilities.ToDataTable(currencies);


            }
            else
            {

                return Ok(new { StatusCode = "Code Not Available" });
            }
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            wbook.Worksheets.Add(dt, file);

            // Prepare the response
            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Provide you file name here
            Response.Headers["content-disposition"] = "attachment;filename=\"" + fileName + "\"";


            // Flush the workbook to the Response.OutputStream
            var memoryStream = new MemoryStream();


            wbook.SaveAs(memoryStream);
           
            memoryStream.Position = 0;
            memoryStream.Close();


            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

        }
   
    

        [HttpGet]
        [Route("ExportToCSV")]
        public async Task<IActionResult> ExportToCSVAsync(string fileName, string Type)
        {



            DataTable dt = new DataTable();
            Random rand = new Random();
            int guid = rand.Next();
            fileName += guid.ToString() + ".csv";
            if (Type.ToLower() == "country")
            {
                List<Country> countries = await _queryRepository.LoadCountries(null, null);


                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                List<City> cities = await _queryRepository.LoadCities(null, null, null);

                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                List<Area> areas = await _queryRepository.LoadAreas(null, null, null, null);



                dt = Utilities.ToDataTable(areas);


            }
            else if (Type.ToLower() == "lockup")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, null, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "majorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUps(null, null, 0, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "minorcode")
            {
                List<LockUp> LockUps = await _queryRepository.LoadLockUpsMinorCode(null, null, null, null);


                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "bank")
            {
                List<Bank> banks = await _queryRepository.LoadBanks(null, null);



                dt = Utilities.ToDataTable(banks);


            }
            else if (Type.ToLower() == "bankbranches")
            {
                List<BankBranches> bankBranches = await _queryRepository.LoadBankBranches(null, null, null);



                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                List<Currency> currencies = await _queryRepository.LoadCurrencies(null, null);



                dt = Utilities.ToDataTable(currencies);


            }
            else
            {

                return Ok(new { StatusCode = "Code Not Available" });
            }
            StringBuilder sb = new StringBuilder();

              string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                Select(column => column.ColumnName).
                                                ToArray();
              sb.AppendLine(string.Join(",", columnNames));

              foreach (DataRow row in dt.Rows)
              {
                  string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                  ToArray();



                  sb.AppendLine(string.Join(",", fields));

              }
            Byte[] myData = Utilities.csvBytesWriter(ref dt);





            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "text/csv";
            //Provide you file name here
            Response.Headers["content-disposition"] = "attachment;filename=\"" + fileName;


            return File(myData, "text/csv", fileName);
        }

    }
}