using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Contracts
{
    public interface ITaskListRepository
    {
        public IEnumerable<TaskList> GetTaskListsByCategId(int id);
        public TaskList GetTaskListById(int id);
        public void CreateTaskList(TaskListInputViewModel tasklists);
        public void DeleteTaskLIst(int id);
        public void UpdateTaskList(int id, string l_name);
        


    }
}
