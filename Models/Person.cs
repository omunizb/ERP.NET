using System;
using System.Collections.Generic;

namespace ERPProject.Models
{
    public abstract class Person : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}
