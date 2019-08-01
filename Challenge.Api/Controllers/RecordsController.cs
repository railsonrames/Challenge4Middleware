using Challenge.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;

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
            string filePath = "data.csv";
            if (ModelState.IsValid)
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(filePath, true))
                    {
                        foreach (var record in jsonReceived)
                        {
                            file.WriteLine($"{record.Id},{record.Name},{record.Status}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Não foi possível gravar o objeto em arquivo, causado por: ", ex);
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
