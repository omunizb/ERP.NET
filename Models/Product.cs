using System;
using System.Collections.Generic;

namespace ERPProject.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public int Stock { get; set; }
        public int Purchases { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
