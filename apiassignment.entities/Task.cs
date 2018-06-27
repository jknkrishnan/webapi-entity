using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiassignment
{
    public class Task
    {
        [Key]
        public int Task_Id { get; set; }
        public int Parent_Id { get; set; }
        public string TaskDesc { get; set; }
        public DateTime strDate { get; set; }
        public DateTime endDate { get; set; }
        public int priority { get; set; } 
    }
}
