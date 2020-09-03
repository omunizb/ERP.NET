using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Models
{
    public class Customer
    {
        [Key]
        public long IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime FirstPurchase { get; set; }
        public DateTime LatestPurchase { get; set; }
        public float TotalExpenditure { get; set; }
        public int TotalPurchases { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BankAccount { get; set; }
    }
}
