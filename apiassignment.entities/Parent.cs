using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiassignment
{
    public class Parent
    {
        [Key]
        public int Parent_Id { get; set; }
        public string Parent_Task { get; set; }
    }
}
