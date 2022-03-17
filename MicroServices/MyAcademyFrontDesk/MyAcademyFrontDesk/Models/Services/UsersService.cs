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
    public class UsersService
    {
        private readonly HttpClient client;
        public UsersService(IHttpClientFactory factory)
        {
            client = factory.CreateClient("UsersServiceAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/login", Content);
            Response.EnsureSuccessStatusCode();
            Json = await Response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponseDTO>(Json);
            return result;
        }


    }
}
