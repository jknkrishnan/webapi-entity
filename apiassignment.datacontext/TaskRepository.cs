using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiassignment
{
    public class TaskRepository
    {
        public List<Task> Gettasks()
        {
            List<Task> ls;
            using (var taskcontext = new TaskContext())
            {
                ls = taskcontext.Task.ToList();
            }
            return ls;
        }

        public List<Task> GetTasksById(int id)
        {
            List<Task> ls;
            using (var taskcontext = new TaskContext())
            {
                ls = taskcontext.Task.Where(p => p.Task_Id == id).ToList();                
            }
            return ls;
        }
    }
}
