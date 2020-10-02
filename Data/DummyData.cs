using ERPProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Adapted from https://github.com/medhatelmasry/HealthAPI/blob/master/HealthAPI/Data/DummyData.cs
namespace ERPProject.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ERPContext>();
            context.Database.EnsureCreated();

            // Look for any events
            if (context.Products != null && context.Products.Any())
                return;

            var products = GetProducts().ToArray();
            context.Products.AddRange(products);
            context.SaveChanges();

            var employees = GetEmployees().ToArray();
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var customers = GetCustomers().ToArray();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var orders = GetOrders().ToArray();
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>() {
                new Product {
                    Name="Earbuds 100X",
                    Category="Electronics",
                    Description = "The best earbuds in the market!",
                    CurrentPrice = 17.99,
                    Stock = 4500,
                    Purchases = 102
                },
                new Product {
                    Name="Blue shirt",
                    Category="Men's Shirts",
                    Description = "A top-quality cotton shirt, in blue",
                    CurrentPrice = 20.49,
                    Stock = 1200,
                    Purchases = 323
                },
                new Product {
                    Name="The Handmaid's Tale",
                    Category="Books",
                    Description = @"#1 New York Times bestseller. Look for The Testaments, the 
                                  sequel to The Handmaid’s Tale, available now. An instant classic 
                                  and eerily prescient cultural phenomenon, from “the patron saint 
                                  of feminist dystopian fiction” (New York Times).Now an 
                                  award-winning Hulu series starring Elizabeth Moss. In Margaret 
                                  Atwood’s dystopian future, environmental disasters and declining 
                                  birthrates have led to a Second American Civil War.The result is 
                                  the rise of the Republic of Gilead, a totalitarian regime that 
                                  enforces rigid social roles and enslaves the few remaining fertile 
                                  women. Offred is one of these, a Handmaid bound to produce children 
                                  for one of Gilead’s commanders.Deprived of her husband, her child, 
                                  her freedom, and even her own name, Offred clings to her memories 
                                  and her will to survive.At once a scathing satire, an ominous 
                                  warning, and a tour de force of narrative suspense, The Handmaid’s 
                                  Tale is a modern classic. Includes an introduction by Margaret 
                                  Atwood. Paperback – March 16, 1998",
                    CurrentPrice = 7.99,
                    Stock = 3004,
                    Purchases = 2809 }
            };
            return products;
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>() {
                new Employee {
                    Name = "Mikaela",
                    Surname = "Gomis",
                    Hired = new DateTime(2018, 9, 15),
                    Salary = 31560.56,
                    Position = "Attendant"
                },
                new Employee {
                    Name = "Kevin",
                    Surname = "Garcia",
                    Hired = new DateTime(2015, 5, 23),
                    Salary = 31560.56,
                    Position = "Attendant"
                },
                new Employee {
                    Name = "Joan",
                    Surname = "Cot",
                    Hired = new DateTime(2019, 10, 5),
                    Salary = 63810.13,
                    Position = "Manager"
                }
            };
            return employees;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer {
                    Name = "Nuria",
                    Surname = "Rossi",
                    Email = "nuriarossi@gmail.com",
                    FirstPurchase = new DateTime(2014, 6, 1, 18, 17, 53),
                    LatestPurchase = new DateTime(2020, 8, 28, 11, 45, 12),
                    TotalExpenditure = 568.33,
                    TotalPurchases = 41,
                    DeliveryAddress = "Calle Enxertos 85, Monsagro, Salamanca, 37532, Spain",
                    BillingAddress = "Calle Enxertos 85, Monsagro, Salamanca, 37532, Spain",
                    BankAccount = "ES9121000418450200051332",
                },
                new Customer {
                    Name = "Hector",
                    Surname = "Roca",
                    Email = "hectorroca@gmail.com",
                    FirstPurchase = new DateTime(2013, 3, 23, 22, 42, 11),
                    LatestPurchase = new DateTime(2020, 6, 11, 18, 10, 24),
                    TotalExpenditure = 445.65,
                    TotalPurchases = 29,
                    DeliveryAddress = "Calle Pascual Yunquera 40, Cortes de Baza, Granada, 18814, Spain",
                    BillingAddress = "Calle Pascual Yunquera 40, Cortes de Baza, Granada, 18814, Spain",
                    BankAccount = "ES4031907163513548452719",
                },
                new Customer {
                    Name = "Alex",
                    Surname = "Perez",
                    Email = "alexperez@gmail.com",
                    FirstPurchase = new DateTime(2017, 1, 29, 9, 9, 55),
                    LatestPurchase = new DateTime(2020, 9, 2, 20, 19, 1),
                    TotalExpenditure = 2899.09,
                    TotalPurchases = 113,
                    DeliveryAddress = "Calle Cuevas de Ambrosio 72, León, León, 24000, Spain",
                    BillingAddress = "Calle Extramuros 11, Valdemoro, Madrid, 28340, Spain",
                    BankAccount = "ES7701824756598176787587",
                },
            };
            return customers;
        }

        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>() {
                new Order {
                    IdCustomer = 1,
                    IdEmployee = 1,
                    IdProduct = 1,
                    Time = new DateTime(2015, 2, 27, 19, 18, 54),
                    Quantity = 1,
                    Price = 14.87,
                    PriceVAT = 17.99,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2015, 3, 2),
                    Delivered = new DateTime(2015, 3, 2)
                },
                new Order {
                    IdCustomer = 2,
                    IdEmployee = 2,
                    IdProduct = 2,
                    Time = new DateTime(2020, 6, 11, 18, 10, 24),
                    Quantity = 1,
                    Price = 16.93,
                    PriceVAT = 20.49,
                    State = "Out for delivery",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 6, 12)
                },
                new Order {
                    IdCustomer = 3,
                    IdEmployee = 3,
                    IdProduct = 3,
                    Time = new DateTime(2017, 1, 29, 9, 9, 55),
                    Devolution = true,
                    Quantity = 1,
                    Price = 6.60,
                    PriceVAT = 7.99,
                    State = "Delivered",
                    Priority = 5,
                    ExpectedDelivery = new DateTime(2017, 2, 2),
                    Delivered = new DateTime(2017, 2, 6)
                },
            };
            return orders;
        }
    }
}
