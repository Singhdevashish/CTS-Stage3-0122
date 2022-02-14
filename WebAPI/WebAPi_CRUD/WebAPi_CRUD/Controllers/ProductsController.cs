using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPi_CRUD.Models;
namespace WebAPi_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Products> productsRepository;
        public ProductsController(IRepository<Products> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: 200, type: typeof(IReadOnlyList<Products>))]
        public IActionResult GetProducts()
        {
            var Products = productsRepository.Get();
            return Ok(Products);
        }

        [HttpGet("{id}", Name ="GetProd")]
        //[Route("{id}")]
        [ProducesResponseType(statusCode: 200, type: typeof(Products))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult GetProduct(int id)
        {
            var Products = productsRepository.Get(p => p.Id == id);
            var Product = Products.FirstOrDefault();
            if (Product == null)
                return NotFound();
            return Ok(Product);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 201, type: typeof(Products))]
        [ProducesResponseType(statusCode: 400)]
        public async Task<IActionResult> AddProduct(Products model)
        {
            productsRepository.Add(model);
            int RowsAffected = await productsRepository.SaveAsync();
            if (RowsAffected == 1)
                //return CreatedAtAction("GetProduct", new { id = model.Id });
                return CreatedAtRoute(routeName: "GetProd", 
                                      routeValues: new { id = model.Id }, 
                                      value: model);
            return BadRequest("Add failed");
        }

        [HttpPut]
        [ProducesResponseType(statusCode: 200, type: typeof(Products))]
        [ProducesResponseType(statusCode: 400)]
        public async Task<IActionResult> UpdateProduct(Products model)
        {
            productsRepository.Update(model);
            int RowsAffected = await productsRepository.SaveAsync();
            if (RowsAffected == 1)
                return Ok(model);
            return BadRequest("Update failed");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 400)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Products = productsRepository.Get(p => p.Id == id);
            var Product = Products.FirstOrDefault();
            if (Product == null)
                return NotFound();

            productsRepository.Delete(Product);
            int RowsAffected = await productsRepository.SaveAsync();

            if (RowsAffected == 1)
                return NoContent();

            return BadRequest("Delete failed");
        }
    }
}
