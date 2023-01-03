using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;
using Toha.QIiik.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toha.QIiik.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ITriangleService _service;

        public TriangleController(ITriangleService service)
        {
            this._service = service;
        }


        // POST api/<TriangleController>
        [HttpPost]
        public ActionResult<string> Post(TrianglePostParam value)
        {
            var result = _service.CheckTypeTriangle(value);

            return Ok(result);
        }


    }
}
