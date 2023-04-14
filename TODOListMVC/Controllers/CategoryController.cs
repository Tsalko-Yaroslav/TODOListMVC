using Microsoft.AspNetCore.Mvc;
using TODOListMVC.Contracts;
using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITaskListRepository _taskListRepository;
        private readonly ITasksRepository _tasksRepository;

        public CategoryController(ICategoryRepository categoryRepository, ITaskListRepository taskListRepository, ITasksRepository tasksRepository )
        {
            _categoryRepository = categoryRepository;
            _taskListRepository = taskListRepository;
            _tasksRepository = tasksRepository;
        }


        public IActionResult Index(int id)
        {

            var CategModel = new CategoryOutputViewModel
            {

                Category = _categoryRepository.GetCategoryById(id),
                TaskLists = _taskListRepository.GetTaskListsByCategId(id),
                Tasks = _tasksRepository.GetTasks(),
            };
            
           
            return View(CategModel);
           
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryInputViewModel categoryInputViewModel)
        {
            _categoryRepository.CreateCategory(categoryInputViewModel);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(int id) 
        {
            var model = new CategoryViewModel
            {
                Category = _categoryRepository.GetCategoryById(id),
            };
            return View(model);
            
        }
        [HttpPost]
        public IActionResult Update(int id, string wantedName)
        {
            _categoryRepository.UpdateCategory(id, wantedName);
            return RedirectToAction("Index/@id", "Category"); ;
        }
    }
}
