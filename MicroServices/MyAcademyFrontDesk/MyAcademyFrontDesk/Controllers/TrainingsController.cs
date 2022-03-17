using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAcademyFrontDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class TrainingsController : Controller
    {
        private readonly TrainingService trainingService;

        public TrainingsController(TrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            trainingService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.UserName = HttpContext.Session.GetString("name");
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("Coach"))
                context.Result = new RedirectToActionResult("Logout", "Users", null);
        }

        public async Task<IActionResult> Index()
        {
            var trainings = await trainingService.GetSessions();
            return View(trainings);
        }
    }
}
