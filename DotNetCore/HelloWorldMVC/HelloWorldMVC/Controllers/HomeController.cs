using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HelloWorldMVC.Models;
namespace HelloWorldMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello from MVC Core");
        }

        public IActionResult GetEmployee()
        {
            var e = new Employee { Id = 101, Name = "Jojo" };
            return Json(e);
        }

        public IActionResult SayHello()
        {
            return View();
        }
    }
}
