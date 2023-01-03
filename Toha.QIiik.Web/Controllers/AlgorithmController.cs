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
    public class AlgorithmController : ControllerBase
    {
        IAlgorithmService _service;

        public AlgorithmController(IAlgorithmService service)
        {
            _service = service;
        }

        // POST api/<AlgorithmController>
        [HttpPost]
        public ActionResult<AlgorithmResponse> Post(ReversePostParam value)
        {
            var result = _service.HashMe(value.StringInput);

            return Ok(result);
        }
    }
}
