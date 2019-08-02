using Challenge.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IO;
using CsvHelper;
using System.Linq;

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
            List<RecordObjectModel> records = new List<RecordObjectModel>();
            try
            {
                using (TextReader reader = new StreamReader("dataArchive.csv"))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Read();
                    csvReader.Configuration.HeaderValidated = false;
                    records = csvReader.GetRecords<RecordObjectModel>().ToList();
                }
                return Ok(records);
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
