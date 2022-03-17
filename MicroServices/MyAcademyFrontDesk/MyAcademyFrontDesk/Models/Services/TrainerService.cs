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
    public class TrainerService : BaseService
    {
        public TrainerService(IHttpClientFactory factory)
        {
            client = factory.CreateClient("TrainerServiceAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
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

        public async Task<TrainerDTO> GetTrainers(int id)
        {
            var Trainer = new TrainerDTO();
            var Response = await client.GetAsync("/api/trainers/"+id);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Trainer = JsonConvert.DeserializeObject<TrainerDTO>(Json);
            return Trainer;
        }

        public async Task<bool> SaveTrainer(TrainerDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/trainers", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode==HttpStatusCode.Created;
        }

        public async Task<bool> UpdateTrainer(TrainerDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PutAsync("/api/trainers", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteTrainer(int trainerID)
        {
            var Response = await client.DeleteAsync("/api/trainers/" + trainerID);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
