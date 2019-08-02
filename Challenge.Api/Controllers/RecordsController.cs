using Challenge.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IO;
using CsvHelper;

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

        [HttpPost]
        [Route("save")]
        public IActionResult PostRecords([FromBody]List<RecordObjectModel> jsonReceived)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (TextWriter writer = new StreamWriter("test.csv", false, System.Text.Encoding.UTF8))
                    {
                        var csv = new CsvWriter(writer);
                        csv.WriteRecords(jsonReceived);
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
