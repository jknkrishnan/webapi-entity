using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace apiassignment
{
    public class ParentContext : DbContext
    {
        public ParentContext()
            : base("name=Context")
        {

        }
        public DbSet<Parent> Parent { get; set; }

    }
}
