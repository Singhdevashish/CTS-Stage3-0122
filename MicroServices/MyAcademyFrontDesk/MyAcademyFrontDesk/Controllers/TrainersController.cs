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
    public class TrainersController : Controller
    {
        private readonly TrainerService trainerService;

        public TrainersController(TrainerService trainerService):base()
        {          
            this.trainerService = trainerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.UserName = HttpContext.Session.GetString("name");
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("Lead"))
                context.Result = new RedirectToActionResult("Logout", "Users", null);
        }

        public async Task<IActionResult> Index()
        {
            var Trainers = await trainerService.GetTrainers();
            return View(Trainers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainerDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await trainerService.SaveTrainer(model);
            if (IsAdded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to add trainer");
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var TrainerDTo = await trainerService.GetTrainers(id);
            if (TrainerDTo == null) return NotFound();
            return View(TrainerDTo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var TrainerDTo = await trainerService.GetTrainers(id);
            if (TrainerDTo == null) return NotFound();
            return View(TrainerDTo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrainerDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            var IsUpdated = await trainerService.UpdateTrainer(model);
            if (IsUpdated)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Failed to save trainer");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var TrainerDTo = await trainerService.GetTrainers(id);
            if (TrainerDTo == null) return NotFound();
            return View(TrainerDTo);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var IsDeleted = await trainerService.DeleteTrainer(id);
            if (IsDeleted) return RedirectToAction("Index");

            var TrainerDTo = await trainerService.GetTrainers(id);
            //Display failure message using view bag
            return View("Delete",TrainerDTo);
        }
    }
}
