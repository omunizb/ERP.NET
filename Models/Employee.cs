using System;

namespace ERPProject.Models
{
    public class Employee : Person
    {
        public DateTime Hired { get; set; }
        public DateTime Departed { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
    }
}
