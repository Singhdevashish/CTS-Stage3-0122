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
    public class CohortsController : ControllerBase
    {
        private readonly IRepository<Cohort> cohortRepository;

        public CohortsController(IRepository<Cohort> cohortRepository)
        {
            this.cohortRepository = cohortRepository;
        }

        [HttpGet]
        public IActionResult GetTrainers()
        {
            var All = BaseSpecification<Cohort>.All;
            var cohorts = cohortRepository.Get(All);
            var Dtos = new List<CohortDTO>();
            foreach (var cohort in cohorts)
                Dtos.Add(new CohortDTO { Id = cohort.Id, CohortCode = cohort.CohortCode });
            return Ok(Dtos);
        }
    }
}
