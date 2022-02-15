using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParameterBinding.Controllers
{
    public class Location
    {
        public int Lattitude { get; set; }
        public int Longitude { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]Location loc)
        {
            return Ok($"Traffic details in lat: {loc.Lattitude} and lon: {loc.Longitude}");
        }

        [HttpPost]
        public IActionResult Validate([FromQuery]string username, [FromBody]string password)
        {
            return Ok($"Access granted : {username}");
        }
    }
}
