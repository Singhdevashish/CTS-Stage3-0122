using AutoMapper;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TrainerManagement.Domain;

namespace TrainerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Lead")]
    public class TrainersController : ControllerBase
    {
        private readonly IRepository<Trainer> trainersRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public TrainersController(IRepository<Trainer> trainersRepository, IMapper mapper, IConfiguration configuration)
        {
            this.trainersRepository = trainersRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TrainerDTO>))]
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

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TrainerDTO))]
        public async Task<IActionResult> Get(int id)
        {
            Trainer trainer = await trainersRepository.GetAsync(id);

            var DTO = mapper.Map<TrainerDTO>(trainer);
            return Ok(DTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TrainerDTO))]
        public async Task<IActionResult> Post(TrainerDTO model)
        {
            Trainer trainer = mapper.Map<Trainer>(model);
            trainersRepository.Add(trainer);
            await trainersRepository.SaveAsync();
            var dto = mapper.Map<TrainerDTO>(trainer);

            var servicebusconnection = configuration["ServiceBusSettings:ConnectionString"];
            var queue = configuration["ServiceBusSettings:QueueName"];

            try
            {
                var client = new ServiceBusClient(servicebusconnection);
                var sender = client.CreateSender(queue);
                var json = JsonSerializer.Serialize(trainer);
                var message = new ServiceBusMessage(json);
                await sender.SendMessageAsync(message);
            }
            catch { }
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
