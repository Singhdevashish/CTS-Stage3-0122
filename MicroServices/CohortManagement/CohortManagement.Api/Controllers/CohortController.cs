using AutoMapper;
using CohortManagement.Api.DTOs;
using CohortManagement.Core;
using CohortManagement.Core.CohortAggregate.Specifications;
using CohortManagement.Core.Interfaces;
using CohortManagement.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CohortController : ControllerBase
    {
        private readonly IRepository<Cohort> cohortRepository;
        private readonly IMapper mapper;
        public CohortController(IRepository<Cohort> cohortRepository, IMapper mapper)
        {
            this.cohortRepository = cohortRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCohorts()
        {
            var getAllSpec = new GetAllCohortsSpecification();
            var cohorts = cohortRepository.Get(getAllSpec);
            var dto = mapper.Map<List<CohortDTO>>(cohorts);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCohortsById(long id)
        {
            var getByIdWithTrainees = new GetCohortByIdWithTraineesSpecification(id);
            var dto = GetCohorts(getByIdWithTrainees);
            return Ok(dto);

        }

        [HttpPost]
        public async Task<IActionResult> AddNewCohort(CohortDTO cohortDTO)
        {
            var cohort = new Cohort(cohortDTO.CohortCode, cohortDTO.TechnologyStack, cohortDTO.Coach);
            Trainee trainee;
            foreach (var traineedto in cohortDTO.Trainees)
            {
                trainee = mapper.Map<Trainee>(traineedto);
                cohort.AddTrainee(trainee);
            }

            cohort= cohortRepository.Add(cohort);
            await cohortRepository.SaveAsync();
            var dto = mapper.Map<CohortDTO>(cohort);
            return StatusCode(201, dto);
        }

        [HttpDelete("{cohortId}/remove/{traineeId}")]
        public async Task<IActionResult> DeleteCohort(long cohortId, long traineeId)
        {
            var getByIdWithTrainees = new GetCohortByIdWithTraineesSpecification(cohortId);
            var cohort = cohortRepository.Get(getByIdWithTrainees).FirstOrDefault();
            if (cohort == null)
                return NotFound();

            cohort.RemoveTrainee(traineeId);
            await cohortRepository.SaveAsync();
            return StatusCode(204);
        }

        private CohortDTO GetCohorts(BaseSpecification<Cohort> specification)
        {
            var cohorts = cohortRepository.Get(specification);
            var dto = mapper.Map<CohortDTO>(cohorts.FirstOrDefault());
            return dto;
        }
    }
}
