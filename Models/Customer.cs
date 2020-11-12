using System;

namespace ERPProject.Models
{
    public class Customer : Person
    {
        public DateTime FirstPurchase { get; set; }
        public DateTime LatestPurchase { get; set; }
        public double TotalExpenditure { get; set; }
        public int TotalPurchases { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BankAccount { get; set; }
    }
}
