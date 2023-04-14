using TODOListMVC.Models;

namespace TODOListMVC.ViewModels
{
    public class CategoryOutputViewModel
    {
        public IEnumerable<TaskList> TaskLists { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Tasks> Tasks { get; set; }
    }
}
