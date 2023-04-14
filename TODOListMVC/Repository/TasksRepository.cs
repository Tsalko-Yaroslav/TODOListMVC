using Dapper;
using System.Data;
using TODOListMVC.Context;
using TODOListMVC.Contracts;
using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Repository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DapperContext _dapperContext;

        public TasksRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public IEnumerable<Tasks> GetTasksByListID(int listID)
        {
            var query = "SELECT * FROM tasks WHERE task_list_id=@listID";
            var parameters = new DynamicParameters();
            parameters.Add("id", listID, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasks = connection.Query<Tasks>(query, parameters);
                return tasks.ToList();
            }
        }
        public IEnumerable<Tasks> GetTasks()
        {
            var query = "SELECT * FROM tasks";

            using (var connection = _dapperContext.CreateConnection())
            {
                var task = connection.Query<Tasks>(query);
                return task.ToList();
            }
        }
       

        public void CreateTask(TaskImputViewModel taskImputViewModel)
        {
            var query = "INSERT INTO tasks VALUES (@t_name, @task_list_id, @deadline_date, @completed)";
            var parameters = new DynamicParameters();
            parameters.Add("t_name", taskImputViewModel.t_name, DbType.String);
            parameters.Add("task_list_id", taskImputViewModel.task_list_id, DbType.Int32);
            parameters.Add("deadline_date", taskImputViewModel.deadline_date, DbType.Date);
            parameters.Add("completed", taskImputViewModel.completed, DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
