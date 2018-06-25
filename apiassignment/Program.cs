using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiassignment
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var parentcontext = new ParentContext())
            {
                parentcontext.Parent.ToList();
            }
            using (var taskcontext = new TaskContext())
            {
                taskcontext.Task.ToList();
            }
        }
    }
}
