using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiassignment.business
{
   public  class ParentBusiness
    {
        public List<Parent> GetParentTasks()
        {
            List<Parent> ls;
            ls = (new ParentRepository().GetParenttasks());
            return ls;
        }

        public List<Parent> GetParentTasksById(int id)
        {
            List<Parent> ls;
            ls = (new ParentRepository().GetParentTasksById(id));
            return ls;
        }
    }
}
