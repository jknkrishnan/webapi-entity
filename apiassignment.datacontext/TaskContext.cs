using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace apiassignment
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            : base("name=Context")
        {

        }
        public DbSet<Task> Task { get; set; }

    }
}
