using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerManagement.Domain;

namespace TrainerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IRepository<Trainer> trainersRepository;
        private readonly IMapper mapper;
        public TrainersController(IRepository<Trainer> trainersRepository, IMapper mapper)
        {
            this.trainersRepository = trainersRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type =typeof(IEnumerable<TrainerDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Trainer> trainers = await trainersRepository.GetAsync();
            //var DTOs = new List<TrainerDTO>();
            //foreach (var trainer in trainers)
            //    DTOs.Add(new TrainerDTO
            //    {
            //        Id = trainer.Id,
            //        Name = trainer.Name,
            //        Email = trainer.Email,
            //        PhoneNumber = trainer.PhoneNumber,
            //        PrimarySkill = trainer.PrimarySkill,
            //        SecondarySkills = trainer.SecondarySkills
            //    });
            var DTOs = mapper.Map<List<TrainerDTO>>(trainers);
            return Ok(DTOs);
        }

        [HttpPost]
        [ProducesResponseType(201, Type =typeof(TrainerDTO))]
        public async Task<IActionResult> Post(TrainerDTO model)
        {
            Trainer trainer = mapper.Map<Trainer>(model);
            trainersRepository.Add(trainer);
            await trainersRepository.SaveAsync();
            var dto = mapper.Map<TrainerDTO>(trainer);
            return StatusCode(201, dto);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(TrainerDTO))]
        public async Task<IActionResult> Put(TrainerDTO model)
        {
            Trainer trainer = mapper.Map<Trainer>(model);
            trainersRepository.Update(trainer);
            await trainersRepository.SaveAsync();
            var dto = mapper.Map<TrainerDTO>(trainer);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{trainerId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int trainerId)
        {
            Trainer trainer = new Trainer { Id = trainerId };
            trainersRepository.Delete(trainer);
            await trainersRepository.SaveAsync();
            return NoContent();
        }
    }
}
