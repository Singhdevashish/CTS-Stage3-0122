using MyAcademyFrontDesk.Models.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Models
{
    public class TrainingService : BaseService
    {
        public TrainingService(IHttpClientFactory factory)
        {
            this.client = factory.CreateClient("TrainingServiceAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public async Task<List<CohortDTO>> GetCohorts()
        {
            List<CohortDTO> Cohorts = new List<CohortDTO>();
            var Response = await client.GetAsync("/api/cohort");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Cohorts = JsonConvert.DeserializeObject<List<CohortDTO>>(Json);
            return Cohorts;
        }

        public async Task<List<TrainerDTO>> GetTrainers()
        {
            var Trainers = new List<TrainerDTO>();
            var Response = await client.GetAsync("/api/trainers");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Trainers = JsonConvert.DeserializeObject<List<TrainerDTO>>(Json);
            return Trainers;
        }

        public async Task<List<TrainingSessionDTO>> GetSessions()
        {
            List<TrainingSessionDTO> sessions = new List<TrainingSessionDTO>();
            var Response = await client.GetAsync("/api/trainingsessions");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            sessions = JsonConvert.DeserializeObject<List<TrainingSessionDTO>>(Json);
            return sessions;
        }
    }
}
