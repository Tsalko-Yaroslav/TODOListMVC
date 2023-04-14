using TODOListMVC.Models;
using TODOListMVC.ViewModels;

namespace TODOListMVC.Contracts
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategoryById(int id);
        public void CreateCategory(CategoryInputViewModel category);
        public void DeleteCategory(int id);
        public void UpdateCategory(int id, string wantedName);

    }
}
