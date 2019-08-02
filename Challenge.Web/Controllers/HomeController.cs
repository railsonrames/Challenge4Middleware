using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge.Web.Models;

namespace Challenge.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //[Get("/api-gestao-dup/v1/desapropriacao/{idDup}/dupgestao")]
            //Task<HttpResponseMessage> GetDupGestaoByIdDup(int idDup);



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
