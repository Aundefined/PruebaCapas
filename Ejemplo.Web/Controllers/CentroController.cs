using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo.Business;
using Ejemplo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ejemplo.Web.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CentroController : ControllerBase
    {
        ICentroBS cBS = null;
        public CentroController(IConfiguration configuration, ICentroBS centroBS)
        {
            cBS = centroBS;
        }

        [HttpGet]
        public IActionResult Get(string nombre)
        {
            var result = cBS.Get(nombre);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(Centro centro)
        {
            cBS.Insert(centro);
            return Ok();
        }
    }
}