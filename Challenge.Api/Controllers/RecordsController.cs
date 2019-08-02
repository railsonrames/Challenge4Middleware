using Challenge.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IO;
using CsvHelper;
using System.Linq;
using Challenge.Api.Mapping;

namespace Challenge.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {

        [HttpGet]
        [Route("list")]
        public ActionResult<IEnumerable<RecordObjectModel>> GetRecords()
        {
            return new List<RecordObjectModel> {
                new RecordObjectModel{
                    Id = 1,
                    Name = "Railson Rames",
                    Status = true
                },
                new RecordObjectModel{
                    Id = 2,
                    Name = "Rayanne de Brito Uchoa",
                    Status = true
                },
                new RecordObjectModel{
                    Id = 3,
                    Name = "Rayanninha Uchoa Rames",
                    Status = true
                }
            };
        }

        [HttpGet]
        [Route("main")]
        public ActionResult<IEnumerable<RecordObjectModel>> MainRecords()
        {
            try
            {
                //var reader = System.IO.File.ReadAllText("dataArchive.csv");
                //Console.WriteLine(reader);

                List<RecordObjectModel> recordList = new List<RecordObjectModel>();

                var csvReader = new CsvReader(new StreamReader("dataArchive.csv"));
                var records = csvReader.GetRecords<RecordObjectModel>();

                foreach (var item in records)
                {
                    RecordObjectModel recordObject = new RecordObjectModel();

                    recordObject.Id = item.Id;
                    recordObject.Name = item.Name;
                    recordObject.Status = item.Status;

                    recordList.Add(recordObject);
                }

                return Ok();
            }
            catch (Exception excep)
            {
                throw new ApplicationException($"Ocorreu um erro ao ler os dados no arquivo CSV, causados por: {excep}");
            }
        }

        [HttpPost]
        [Route("save")]
        public IActionResult PostRecords([FromBody]List<RecordObjectModel> jsonReceived)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TextWriter writer = new StreamWriter("dataArchive.csv", false, System.Text.Encoding.UTF8))
                    {
                        var csvWriter = new CsvWriter(writer);
                        csvWriter.WriteRecords(jsonReceived);
                        writer.Close();
                    }
                }
                catch (Exception excep)
                {
                    throw new ApplicationException($"Ocorreu um erro ao gravar os dados no arquivo CSV, causados por: {excep}");
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
