using Dapper;
using System;
using System.Data;
using TODOListMVC.Context;
using TODOListMVC.Contracts;
using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Repository
{
    public class TaskListRepository :ITaskListRepository
    {
        private readonly DapperContext _dapperContext;

        public TaskListRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void CreateTaskList(TaskListInputViewModel tasklists)
        {
            var query = "INSERT INTO tasklist VALUES (@l_name, @category_id)";
            var parameters = new DynamicParameters();
            parameters.Add("l_name", tasklists.l_name, DbType.String);
            parameters.Add("category_id", tasklists.category_id, DbType.Int32);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void DeleteTaskLIst(int id)
        {
            var query = "DELETE FROM tasklist WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }

        public TaskList GetTaskListById(int id)
        {
            var query = "SELECT * FROM tasklist WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasklist = connection.QuerySingleOrDefault<TaskList>(query, parameters);
                return tasklist;
            }
        }

        public IEnumerable<TaskList> GetTaskListsByCategId(int id)
        {
            var query = "SELECT * FROM tasklist WHERE category_id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasklist = connection.Query<TaskList>(query, parameters);
                return tasklist.ToList();
            }
        }

        public void UpdateTaskList(int id, string l_name)
        {
            var query = "UPDATE tasklist SET l_name = @l_name WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("l_name", l_name, DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }
        
        
    }
}
