using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mvc_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Mvc_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> productRepository;

        public ProductsController(IRepository<Product> productRepositoryt)
        {
            this.productRepository = productRepositoryt;         
        }

        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            productRepository.Add(product);
            await productRepository.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            productRepository.Update(product);
            await productRepository.SaveAsync();

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            productRepository.Delete(product);
            await productRepository.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
