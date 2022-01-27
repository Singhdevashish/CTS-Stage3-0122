using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mvc_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mvc_CRUD.Filters;

namespace Mvc_CRUD.Controllers
{
    [TypeFilter(typeof(MyCustomExceptionFilter))]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly ILogger<ProductsController> logger;
        public ProductsController(IRepository<Product> productRepositoryt,
                                  ILogger<ProductsController> logger)
        {
            this.productRepository = productRepositoryt;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            logger.LogInformation("Index method executed");
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

        public IActionResult Search()
        {
            throw new NotImplementedException();
            //throw new ArgumentException();
        }
    }
}
