using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Controllers
{
    [Route("")]
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _repo;

        public CategoriesController(ICategoryService categoryService, ICategoryRepository repo)
        {
            _categoryService = categoryService;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsyncmuhannad();
            return categories;
        }

        [HttpPost]
        public string POST()
        {
            return "muhannad imad from post method";
        }
     
    }
}