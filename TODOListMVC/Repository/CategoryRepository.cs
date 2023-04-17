using Dapper;
using System.Data;
using TODOListMVC.Context;
using TODOListMVC.Contracts;
using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _dapperContext;

        public CategoryRepository (DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void CreateCategory(CategoryInputViewModel category)
        {
            var query = "INSERT INTO category VALUES (@c_name)";
            var parameters = new DynamicParameters();
            parameters.Add("c_name", category.c_name, DbType.String);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

       

        public void DeleteCategory(int id)
        {
            var query = "DELETE FROM category WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }

        public IEnumerable<Category> GetCategories()
        {
            var query = "SELECT * FROM category";

            using(var connection =_dapperContext.CreateConnection())
            {
                var category = connection.Query<Category>(query);
                return category.ToList();
            }
        }
        

        public Category GetCategoryById(int id)
        {
            var query = "SELECT * FROM category WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            using (var connection = _dapperContext.CreateConnection())
            {
                var category = connection.QuerySingleOrDefault<Category>(query, parameters);
                return category;
            }
            
        }

        public void UpdateCategory(int id, string c_name)
        {
            var query = "UPDATE category SET c_name = @c_name WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("c_name", c_name, DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Execute(query, parameters);

            }
        }
    }
}
