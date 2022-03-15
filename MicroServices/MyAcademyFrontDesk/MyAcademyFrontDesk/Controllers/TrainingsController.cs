using Microsoft.AspNetCore.Mvc;
using MyAcademyFrontDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly TrainingService trainingService;

        public TrainingsController(TrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        public async Task<IActionResult> Index()
        {
            var trainings = await trainingService.GetSessions();
            return View(trainings);
        }
    }
}
