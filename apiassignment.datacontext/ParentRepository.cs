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
    }
}
