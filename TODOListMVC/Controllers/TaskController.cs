using Microsoft.AspNetCore.Mvc;
using TODOListMVC.Contracts;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasksRepository _taskRepository;

        public TaskController(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskImputViewModel taskInputViewModel, int category_id)
        {
            _taskRepository.CreateTask(taskInputViewModel);

            return RedirectToAction("Index", "Category", new { @id = category_id });
        }
        public IActionResult Delete(int id, int category_id)
        {
            _taskRepository.DeleteTask(id);
            return RedirectToAction("Index", "Category", new { @id = category_id });
        }
        public IActionResult Update(int id, int category_id)
        {
            var model = new TaskViewModel
            {
                Task = _taskRepository.GetTaskById(id),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(TaskUpdateViewModel taskUpdateViewModel, int category_id)
        {
            _taskRepository.UpdateTask(taskUpdateViewModel);
            return RedirectToAction("Index", "Category", new { @id = category_id });
        }
        public IActionResult Check(int id, int category_id) 
        {
            _taskRepository.SetCheckPointById(id);
            return RedirectToAction("Index", "Category", new { @id = category_id });

        }
        public IActionResult UnCheck(int id, int category_id)
        {
            _taskRepository.SetUncheckPointByid(id);
            return RedirectToAction("Index", "Category", new { @id = category_id });
        }
    }
        
}
