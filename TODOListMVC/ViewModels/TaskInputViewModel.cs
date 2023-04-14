namespace TODOListMVC.ViewModels
{
    public class TaskImputViewModel
    {
        public int Id { get; set; } 
        public string t_name { get; set; }
        public int task_list_id { get; set; }
        public DateTime deadline_date { get; set; }
        public bool completed { get; set; }
    }
}
