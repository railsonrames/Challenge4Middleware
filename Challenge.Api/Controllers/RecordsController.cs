using Challenge.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

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
                //to do
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
