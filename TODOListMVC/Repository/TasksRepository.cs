using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
        public Tasks GetTaskById(int id)
        {
            var query = "SELECT * FROM tasks WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using(var connection = _dapperContext.CreateConnection())
            {
                var task = connection.QuerySingleOrDefault<Tasks>(query, parameters);
                return task;
            }
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
        public void DeleteTask(int id)
        {
            var query = "DELETE FROM tasks WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }
        public void UpdateTask(TaskUpdateViewModel task)
        {
            var query = "UPDATE tasks SET t_name=@t_name, deadline_date=@deadline_date WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", task.id, DbType.Int32);
            parameters.Add("t_name", task.t_name.ToString(), DbType.String);
            parameters.Add("deadline_date", task.deadline_date, DbType.Date);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }

        }
        public void SetCheckPointById(int id)
        {
            var query = "UPDATE tasks SET completed=1 WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }
        public void SetUncheckPointByid(int id)
        {
            var query = "UPDATE tasks SET completed=0 WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }
    }
}
