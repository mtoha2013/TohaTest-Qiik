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
    public class ReverseWordController : ControllerBase
    {
        IReverseWordService _service;

        public ReverseWordController(IReverseWordService service)
        {
            _service = service;
        }
        // POST api/<ReverseWordController>
        [HttpPost]
        public ActionResult<string> Post(ReversePostParam value)
        {
            var result = _service.ReverseWord(value.StringInput);

            return Ok(result);
        }

    }
}
