using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyFrontDesk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class CohortsController : Controller
    {
        private readonly CohortService cohortService;
        private const string TRAINEES_TEMPDATA_KEY = "Trainees";

        public CohortsController(CohortService cohortService)
        {
            this.cohortService = cohortService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            cohortService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.UserName = HttpContext.Session.GetString("name");
            ViewBag.Role = HttpContext.Session.GetString("role");
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("Lead"))
                context.Result = new RedirectToActionResult("Logout", "Users", null);
        }
        public async Task<IActionResult> Index()
        {
            var Cohorts = await cohortService.GetCohorts();
            return View(Cohorts);
        }

        public async Task<IActionResult> Details(long id)
        {
            var Cohort = await cohortService.GetCohort(id);
            if (Cohort == null) return NotFound();
            return View(Cohort);
        }

        [Route("Cohorts/Delete/{cohortId}/{traineeId}", Name = "DeleteTrainee")]
        public async Task<IActionResult> Delete(long cohortId, long traineeId)
        {
            var IsRemoved = await cohortService.RemoveTrainee(cohortId, traineeId);

            return RedirectToAction("Details", new { id = cohortId });

        }

        public IActionResult Create()
        {
            var Technologies = new List<string> { "DotNet", "Java", "DWH", "Testing" };
            ViewBag.Technologies = new SelectList(Technologies);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CohortDTO model)
        {
            var Technologies = new List<string> { "DotNet", "Java", "DWH", "Testing" };
            ViewBag.Technologies = new SelectList(Technologies);

            if (!ModelState.IsValid) return View(model);
            if (!TempData.ContainsKey(TRAINEES_TEMPDATA_KEY))
            {
                ModelState.AddModelError("", "Atleast 1 trainee required to create a cohort");
                return View(model);
            }

            var Json = TempData.Peek(TRAINEES_TEMPDATA_KEY).ToString();
            model.Trainees = JsonConvert.DeserializeObject<List<TraineeDTO>>(Json);


            var IsAdded = await cohortService.AddCohort(model);
            if (IsAdded)
            {
                TempData.Remove(TRAINEES_TEMPDATA_KEY);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could not save cohort");
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTrainee(TraineeDTO trainee)
        {
            trainee.DateOfJoining = DateTime.Now;
            List<TraineeDTO> trainees = new List<TraineeDTO>();
            if (TempData.ContainsKey(TRAINEES_TEMPDATA_KEY))
            {
                var Json = TempData.Peek(TRAINEES_TEMPDATA_KEY).ToString();
                trainees = JsonConvert.DeserializeObject<List<TraineeDTO>>(Json);
            }
            trainees.Add(trainee);
            TempData[TRAINEES_TEMPDATA_KEY] = JsonConvert.SerializeObject(trainees);
            return PartialView("_pvListTrainees",trainees);
        }
    }
}
