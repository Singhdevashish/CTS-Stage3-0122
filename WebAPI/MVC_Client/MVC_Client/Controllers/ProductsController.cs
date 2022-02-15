using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MVC_Client.Models;
using Newtonsoft.Json;

namespace MVC_Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient http;
        public ProductsController(IHttpClientFactory factory)
        {
            http = factory.CreateClient("myapi");
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {
            var response = await http.GetAsync("api/products");
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{

            //}
            //else if(response.StatusCode== System.Net.HttpStatusCode.NotFound)
            //{

            //}
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (!ModelState.IsValid) return View(model);

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await http.PostAsync("api/products", content);

            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
    
        public async Task<IActionResult> Details(int id)
        {
            var response = await http.GetAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Product p = JsonConvert.DeserializeObject<Product>(json);
            return View(p);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await http.GetAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Product p = JsonConvert.DeserializeObject<Product>(json);
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            if (!ModelState.IsValid) return View(model);

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await http.PutAsync("api/products", content);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await http.GetAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Product p = JsonConvert.DeserializeObject<Product>(json);
            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await http.DeleteAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

    }
}
