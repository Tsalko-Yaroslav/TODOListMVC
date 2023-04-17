using TODOListMVC.Models;

namespace TODOListMVC.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public Tasks Task { get; set; }
    }
}
