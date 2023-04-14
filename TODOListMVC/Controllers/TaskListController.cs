using Microsoft.AspNetCore.Mvc;
using TODOListMVC.Contracts;
using TODOListMVC.Repository;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListRepository _taskListRepository;

        public TaskListController(ITaskListRepository taskListRepository)
        {
            
            _taskListRepository = taskListRepository;
            
        }
        public IActionResult Create(int id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult Create(TaskListInputViewModel taskListInputViewModel) 
        {
            _taskListRepository.CreateTaskList(taskListInputViewModel);

            return RedirectToAction("Index", "Category", new { @id = taskListInputViewModel.category_id });
        }

        public IActionResult Delete(int id, int categoryID)
        {
            _taskListRepository.DeleteTaskLIst(id);
            return RedirectToAction("Index", "Category", new { @id = categoryID });
        }
    
    }
    
    
}
