using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models
{
    public class Product
    {
        [Key]
        public long IdProduct { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float CurrentPrice { get; set; }
        public int Stock { get; set; }
        public int Purchases { get; set; }
    }
}
