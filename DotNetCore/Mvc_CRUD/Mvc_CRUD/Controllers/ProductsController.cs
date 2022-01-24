using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mvc_CRUD.Models;
namespace Mvc_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ProductsDbContext context = new ProductsDbContext()
        private readonly ProductsDbContext context;
        public ProductsController(ProductsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var queryProducts = from p in context.Products
                                select p;
            var products = queryProducts.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
