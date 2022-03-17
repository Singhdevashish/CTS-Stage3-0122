using Microsoft.AspNetCore.Mvc;
using MyAcademyFrontDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MyAcademyFrontDesk.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var Result = await usersService.Login(model);

            HttpContext.Session.SetString("token", Result.jwt);
            HttpContext.Session.SetString("name", Result.name);
            HttpContext.Session.SetString("role", Result.role);

            if (Result.role.Equals("Lead"))
                return RedirectToAction("Index", "Trainers");
            else if (Result.role.Equals("Coach"))
                return RedirectToAction("Index", "Trainings");
            ModelState.AddModelError("", "Cannot identify the user");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
