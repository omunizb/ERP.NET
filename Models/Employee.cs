using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ERPProject.Models
{
    public class Employee : IdentityUser<Guid>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Hired { get; set; }
        public DateTime? Departed { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }

        public List<Order> Orders { get; set; }
    }
}
