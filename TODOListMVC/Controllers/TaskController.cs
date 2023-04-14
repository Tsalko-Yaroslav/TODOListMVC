using Microsoft.AspNetCore.Mvc;
using TODOListMVC.Contracts;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasksRepository _taskListRepository;

        public TaskController(ITasksRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskImputViewModel taskInputViewModel, int category_id)
        {
            _taskListRepository.CreateTask(taskInputViewModel);

            return RedirectToAction("Index", "Category", new { @id = category_id });
        }
    }
}
