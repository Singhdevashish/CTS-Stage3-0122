using AutoMapper;
using Azure.Messaging.ServiceBus;
using CohortManagement.Api.DTOs;
using CohortManagement.Core;
using CohortManagement.Core.CohortAggregate.Specifications;
using CohortManagement.Core.Interfaces;
using CohortManagement.Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CohortManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Lead")]
    public class CohortController : ControllerBase
    {
        private readonly IRepository<Cohort> cohortRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public CohortController(IRepository<Cohort> cohortRepository, IMapper mapper, IConfiguration configuration)
        {
            this.cohortRepository = cohortRepository;
            this.mapper = mapper;
            this.configuration = configuration;
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

            var PayLoad = new { Id = cohort.Id, CohortCode = cohort.CohortCode };
            var servicebusconnection = configuration["ServiceBusSettings:ConnectionString"];
            var queue = configuration["ServiceBusSettings:Cohort_Q"];

          
            try
            {
                var client = new ServiceBusClient(servicebusconnection);
                var sender = client.CreateSender(queue);
                var json = JsonSerializer.Serialize(PayLoad);
                var message = new ServiceBusMessage(json);
                await sender.SendMessageAsync(message);
            }
            catch
            {

            }

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
