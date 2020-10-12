using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models
{
    public class Order : IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Customer")]
        public long IdCustomer { get; set; }

        [ForeignKey("Product")]
        public long IdProduct { get; set; }

        [ForeignKey("Employee")]
        public long IdEmployee { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double PriceVAT { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public DateTime Delivered { get; set; }
    }
}
