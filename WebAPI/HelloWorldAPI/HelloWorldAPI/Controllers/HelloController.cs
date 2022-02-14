using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get executed");
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Post executed");
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Put executed");
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete executed");
        }
    }
}
