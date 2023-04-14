using Microsoft.AspNetCore.Mvc;
using TODOListMVC.Contracts;
using TODOListMVC.Models;

namespace TODOListMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Categories = _categoryRepository.GetCategories()
            };
            return View(model);
        }
        
    }
}
