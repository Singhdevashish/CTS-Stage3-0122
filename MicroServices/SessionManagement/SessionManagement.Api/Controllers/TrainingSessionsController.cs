using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Api.DTOs;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using SessionManagement.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSessionsController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public TrainingSessionsController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddSession(TrainingSessionDTO dto)
        {
            TrainingDates dates = new TrainingDates(dto.FromDate, dto.ToDate);
            TrainingLocation location = new TrainingLocation(dto.Location, dto.IsVirtual);
            TrainingSession entity = new TrainingSession(dto.TrainerId, dto.CohortId, dates, location);

            entity = await sessionService.Add(entity);
            return StatusCode(201);
        }

        [HttpGet]
        [ProducesResponseType(200, Type =typeof(IEnumerable<ReadTrainingSessionDTO>))]
        public IActionResult GetSessions()
        {
            var Sessions = sessionService.GetSessions();
            var Dtos = new List<ReadTrainingSessionDTO>();
            foreach (var session in Sessions)
            {
                Dtos.Add(new ReadTrainingSessionDTO()
                {
                    Id = session.Id,
                    TrainerId = session.TrainerId,
                    CohortId = session.CohortId,
                    FromDate = session.Dates.FromDate,
                    ToDate = session.Dates.ToDate,
                    Location = session.Location.Location,
                    IsVirtual = session.Location.IsVirtual,
                    CohortCode = sessionService.GetCohortCode(session),
                    TrainerName = sessionService.GetTrainerName(session)
                });
            }
            return Ok(Dtos);
        }

    }
}
