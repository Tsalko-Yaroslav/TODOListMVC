﻿using TODOListMVC.Models;

namespace TODOListMVC.ViewModels
{
    public class TaskListViewModel
    {
        public IEnumerable<TaskList> TaskLists { get; set; }
        public TaskList TaskList { get; set; }
    }
}
