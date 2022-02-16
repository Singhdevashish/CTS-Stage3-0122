using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Here is a list of orders");
        }

        [Authorize(Roles ="Customers")]
        [HttpGet("method1")]
        public IActionResult DemoMethod()
        {
            return Ok("Here is a list of orders");
        }
    }
}
