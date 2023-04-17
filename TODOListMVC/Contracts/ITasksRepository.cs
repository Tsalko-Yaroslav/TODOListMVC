using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Contracts
{
    public interface ITasksRepository
    {
        public IEnumerable<Tasks> GetTasksByListID(int listID);
        public IEnumerable<Tasks> GetTasks();
        public Tasks GetTaskById(int id);
        public void CreateTask(TaskImputViewModel taskImputViewModel);
        public void DeleteTask(int id);
        public void UpdateTask(TaskUpdateViewModel task);
        public void SetCheckPointById(int id);
        public void SetUncheckPointByid(int id);
    }
}
