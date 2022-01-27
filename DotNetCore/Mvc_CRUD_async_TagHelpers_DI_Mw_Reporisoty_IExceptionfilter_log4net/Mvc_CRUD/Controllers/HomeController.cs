using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            return Content("Only accesible to logged in users");
        }
    }
}
