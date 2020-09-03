using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models
{
    public class Employee
    {
        [Key]
        public long IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Hired { get; set; }
        public DateTime Departed { get; set; }
        public float Salary { get; set; }
        public string Position { get; set; }
    }
}
