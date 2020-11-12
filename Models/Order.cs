using System;

namespace ERPProject.Models
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double PriceVAT { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public DateTime Delivered { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Employee Employee { get; set; }
    }
}
