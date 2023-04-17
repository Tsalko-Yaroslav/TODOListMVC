using Microsoft.AspNetCore.Mvc;
using System.Text;
using TODOListMVC.Contracts;
using TODOListMVC.Models;
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
        public IActionResult Update(int id)
        {
            var model = new TaskListViewModel
            {
                TaskList = _taskListRepository.GetTaskListById(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id, string l_name) 
        {
            _taskListRepository.UpdateTaskList(id,l_name);
          
            return RedirectToAction("Index","Category", new {id= _taskListRepository.GetTaskListById(id).category_id});

        }
    
    }
    
    
}
