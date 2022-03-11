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
    public class CohortService
    {
        private readonly HttpClient client;
        public CohortService(IHttpClientFactory factory)
        {
            this.client = factory.CreateClient("CohortServiceAPI");
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

        public async Task<CohortDTO> GetCohort(long cohortId)
        {
            CohortDTO cohort = new CohortDTO();
            var Response = await client.GetAsync("/api/cohort/" + cohortId);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            cohort = JsonConvert.DeserializeObject<CohortDTO>(Json);
            return cohort;
        }

        public async Task<bool> RemoveTrainee(long cohortId, long traineeId)
        {
            var Response = await client.DeleteAsync($"/api/cohort/{cohortId}/remove/{traineeId}");
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> AddCohort(CohortDTO cohort)
        {
            var Json = JsonConvert.SerializeObject(cohort);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            var Response = await client.PostAsync("/api/cohort", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }
    }
}
