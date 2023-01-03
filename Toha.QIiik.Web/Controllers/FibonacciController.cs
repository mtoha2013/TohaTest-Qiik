using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toha.QIiik.Web.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toha.QIiik.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        IFibonacciService _service;

        public FibonacciController(IFibonacciService service)
        {
            _service = service;
        }

        // POST api/<FibonacciController>
        [HttpPost]
        public ActionResult<decimal> Post([FromBody] int valueInputFibonacci = 0)
        {
            if (valueInputFibonacci < 0)
                return BadRequest("Fibonacci Value cannot be negative");

            var result = _service.CalculateFibonacci(valueInputFibonacci);
            return Ok(result);
        }

    }
}
