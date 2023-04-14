using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Contracts
{
    public interface ITasksRepository
    {
        public IEnumerable<Tasks> GetTasksByListID(int listID);
        public IEnumerable<Tasks> GetTasks();
        public void CreateTask(TaskImputViewModel taskImputViewModel);
    }
}
