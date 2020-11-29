using System;
using System.Collections.Generic;

namespace ERPProject.Models
{
    public class Customer : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime FirstPurchase { get; set; }
        public DateTime LatestPurchase { get; set; }
        public double TotalExpenditure { get; set; }
        public int TotalPurchases { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BankAccount { get; set; }

        public List<Order> Orders { get; set; }
    }
}
