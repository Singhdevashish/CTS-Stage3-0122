using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Api.DTOs;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using SessionManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IRepository<Trainer> trainersRepository;

        public TrainersController(IRepository<Trainer> trainersRepository)
        {
            this.trainersRepository = trainersRepository;
        }

        [HttpGet]
        public IActionResult GetTrainers()
        {
            var All = BaseSpecification<Trainer>.All;
            var trainers = trainersRepository.Get(All);
            var Dtos = new List<TrainerDTO>();
            foreach (var trainer in trainers)
                Dtos.Add(new TrainerDTO { Id = trainer.Id, Name = trainer.Name });
            return Ok(Dtos);
        }
    }
}
