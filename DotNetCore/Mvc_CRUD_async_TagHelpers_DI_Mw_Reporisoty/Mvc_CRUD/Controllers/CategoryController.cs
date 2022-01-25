using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc_CRUD.Models;
namespace Mvc_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly IRepository<Category> categoryRepository;

        public CategoryController(IRepository<Category> categoryRepo)
        {
            this.categoryRepository = categoryRepo;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await categoryRepository.GetAsync();
            //var data = await categoryRepository.GetAsync(c => c.Name.Contains("e"));
            var data = await categoryRepository.GetAsync(c => c.Id > 2);
            return View(data);
        }
    }
}
