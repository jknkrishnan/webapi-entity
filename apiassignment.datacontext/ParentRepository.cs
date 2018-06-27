using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiassignment
{
    public class ParentRepository
    {
        public List<Parent> GetParenttasks()
        {
            List<Parent> ls;
            using (var parentcontext = new ParentContext())
            {
                ls = parentcontext.Parent.ToList();
            }
            return ls;
        }

        public List<Parent> GetParentTasksById(int id)
        {
            List<Parent> ls;
            using (var parentcontext = new ParentContext())
            {
                ls = parentcontext.Parent.Where(p => p.Parent_Id == id).ToList();
            }
            return ls;
        }

        public List<Parent> GetParentTasksByName(string name)
        {
            List<Parent> ls;
            using (var parentcontext = new ParentContext())
            {
                ls = parentcontext.Parent.Where(p => p.Parent_Task == name).ToList();
            }
            return ls;
        }

        public List<Parent> PostTaskById(Parent ts)
        {
            int key = 0;
            List<Parent> ls;
            { 
                using (var taskcontext = new ParentContext())
                {
                    taskcontext.Parent.Add(ts);
                    taskcontext.SaveChanges();
                    key = ts.Parent_Id;
                    ls = taskcontext.Parent.Where(p => p.Parent_Id == key).ToList();

                }
            }
            return ls;
        }
    }
}
