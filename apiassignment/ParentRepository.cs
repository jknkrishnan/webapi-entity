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
    }
}
