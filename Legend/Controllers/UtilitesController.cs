using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Engine.Helpers;
using Engine.IRepository;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> ExportToPdf(string fileName, string Type)
        {
           


            DataTable dt = new DataTable();
            Random rand = new Random();
            int guid = rand.Next();
            fileName += guid.ToString() + ".pdf";
            if (Type.ToLower() == "country")
            {
                IList list = await _queryRepository.LoadCountries(null, null);
                List<Country> countries = list as  List<Country>;

                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                IList list = await _queryRepository.LoadCities(null, null,null);
                List<City> cities = list as List<City>;
                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                IList list = await _queryRepository.LoadAreas(null, null, null, null);

                List<Area> areas = list as List<Area>;

                dt = Utilities.ToDataTable(areas);
             

            }
            else if (Type.ToLower() == "lockup")
            {
                IList list = await _queryRepository.LoadLockUps(null, null, null, null);

                List<LockUp> LockUps = list as List<LockUp>;

                dt = Utilities.ToDataTable(LockUps);
           

            }
            else if (Type.ToLower() == "bank")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Bank> banks = list as List<Bank>;

                dt = Utilities.ToDataTable(banks);
        

            }
            else if (Type.ToLower() == "bankbranches")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<BankBranches> bankBranches = list as List<BankBranches>;

                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Currency> currencies = list as List<Currency>;

                dt = Utilities.ToDataTable(currencies);
            

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
                IList list = await _queryRepository.LoadCountries(null, null);
                List<Country> countries = list as List<Country>;

                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                IList list = await _queryRepository.LoadCities(null, null, null);
                List<City> cities = list as List<City>;
                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                IList list = await _queryRepository.LoadAreas(null, null, null, null);

                List<Area> areas = list as List<Area>;

                dt = Utilities.ToDataTable(areas);


            }
            else if (Type.ToLower() == "lockup")
            {
                IList list = await _queryRepository.LoadLockUps(null, null, null, null);

                List<LockUp> LockUps = list as List<LockUp>;

                dt = Utilities.ToDataTable(LockUps);


            }
            else if (Type.ToLower() == "bank")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Bank> banks = list as List<Bank>;

                dt = Utilities.ToDataTable(banks);


            }
            else if (Type.ToLower() == "bankbranches")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<BankBranches> bankBranches = list as List<BankBranches>;

                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Currency> currencies = list as List<Currency>;

                dt = Utilities.ToDataTable(currencies);


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
            memoryStream.WriteTo(Response.Body);
            memoryStream.Position = 0;
            memoryStream.Close();


            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

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
                IList list = await _queryRepository.LoadCountries(null, null);
                List<Country> countries = list as  List<Country>;

                dt = Utilities.ToDataTable(countries);
            }
            else if (Type.ToLower() == "city")
            {
                IList list = await _queryRepository.LoadCities(null, null,null);
                List<City> cities = list as List<City>;
                dt = Utilities.ToDataTable(cities);
            }
            else if (Type.ToLower() == "area")
            {
                IList list = await _queryRepository.LoadAreas(null, null, null, null);

                List<Area> areas = list as List<Area>;

                dt = Utilities.ToDataTable(areas);
             

            }
            else if (Type.ToLower() == "lockup")
            {
                IList list = await _queryRepository.LoadLockUps(null, null, null, null);

                List<LockUp> LockUps = list as List<LockUp>;

                dt = Utilities.ToDataTable(LockUps);
           

            }
            else if (Type.ToLower() == "bank")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Bank> banks = list as List<Bank>;

                dt = Utilities.ToDataTable(banks);
        

            }
            else if (Type.ToLower() == "bankbranches")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<BankBranches> bankBranches = list as List<BankBranches>;

                dt = Utilities.ToDataTable(bankBranches);


            }
            else if (Type.ToLower() == "currency")
            {
                IList list = await _queryRepository.LoadBanks(null, null);

                List<Currency> currencies = list as List<Currency>;

                dt = Utilities.ToDataTable(currencies);
            

            }

            /*  StringBuilder sb = new StringBuilder();

              string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                Select(column => column.ColumnName).
                                                ToArray();
              sb.AppendLine(string.Join(",", columnNames));

              foreach (DataRow row in dt.Rows)
              {
                  string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                  ToArray();



                  sb.AppendLine(string.Join(",", fields));

              }*/
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