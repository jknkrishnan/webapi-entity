using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public List<Task> PostTaskById(Task ts)
        {
            int key = 0;
            List<Task> ls;
            using (var taskcontext = new TaskContext())
            {
                taskcontext.Task.Add(ts);
                taskcontext.SaveChanges();
                key = ts.Task_Id;
                ls = taskcontext.Task.Where(p => p.Task_Id == key).ToList();
                
            }
            return ls;
        }

        public List<Task> PutTaskById(Task ts)
        {
            int key = 0;
            List<Task> ls;
            using (var taskcontext = new TaskContext())
            {
                taskcontext.Entry(ts).State = EntityState.Modified;
                taskcontext.SaveChanges();
                key = ts.Task_Id;
                ls = taskcontext.Task.Where(p => p.Task_Id == key).ToList();

            }
            return ls;
        }

        public int DeleteTaskById(int id)
        {
            int l = 0;
            using (var taskcontext = new TaskContext())
            {
               Task ts = taskcontext.Task.Find(id);
               taskcontext.Task.Remove(ts);
               taskcontext.SaveChanges();
               l = ts.Task_Id;
            }
            return l;
        }
    }
}
