﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiassignment.business
{
    public class TaskBusiness
    {
        public List<Task> GetTasks()
        {
            List<Task> ls;
            ls = (new TaskRepository().Gettasks());
            return ls;
        }

        public List<Task> GetTasksById(int Id)
        {
            List<Task> ls;
            ls = (new TaskRepository().GetTasksById(Id));
            return ls;
        }
    }
}