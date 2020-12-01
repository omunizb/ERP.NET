﻿using ERPProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Adapted from https://github.com/medhatelmasry/HealthAPI/blob/master/HealthAPI/Data/DummyData.cs
namespace ERPProject.Data
{
    public class DbInitializer
    {
        static readonly Guid[,] IDs = new Guid[3, 3] {
            { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
            { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
            { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
        };
        public  static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ERPContext>();
            context.Database.EnsureCreated();

            // Look for any products
            if (context.Products != null && context.Products.Any())
                return;

            var products = GetProducts().ToArray();
            context.Products.AddRange(products);
            context.SaveChanges();

            var customers = GetCustomers().ToArray();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            await GetUsers(serviceProvider);

            var orders = GetOrders().ToArray();
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>() {
                new Product {
                    Id = IDs[0, 0],
                    Name="Earbuds 100X",
                    Category="Electronics",
                    Description = "The best earbuds on the market!",
                    CurrentPrice = 17.99,
                    Stock = 4500,
                    Purchases = 102
                },
                new Product {
                    Id = IDs[0, 1],
                    Name="Blue shirt",
                    Category="Men's Shirts",
                    Description = "A top-quality cotton shirt, in blue",
                    CurrentPrice = 20.49,
                    Stock = 1200,
                    Purchases = 323
                },
                new Product {
                    Id = IDs[0, 2],
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

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer {
                    Id = IDs[2, 0],
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
                    Id = IDs[2, 1],
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
                    Id = IDs[2, 2],
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
                    CustomerId = IDs[2, 0],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 0],
                    Time = new DateTime(2015, 2, 27, 19, 18, 54),
                    Quantity = 1,
                    Price = 14.87,
                    PriceVAT = 17.99,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2015, 3, 2),
                    Delivered = new DateTime(2015, 3, 2, 11, 25, 04)
                },
                new Order {
                    CustomerId = IDs[2, 1],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 1],
                    Time = new DateTime(2020, 6, 11, 18, 10, 24),
                    Quantity = 1,
                    Price = 16.93,
                    PriceVAT = 20.49,
                    State = "Out for delivery",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 6, 12),
                    Delivered = new DateTime(2020, 6, 12, 16, 11, 34)
                },
                new Order {
                    CustomerId = IDs[2, 2],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 2],
                    Time = new DateTime(2017, 1, 29, 9, 9, 55),
                    Quantity = 1,
                    Price = 6.60,
                    PriceVAT = 7.99,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2017, 2, 2),
                    Delivered = new DateTime(2017, 2, 6, 12, 44, 57)
                },
            };
            return orders;
        }
        public static async Task GetUsers(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ERPContext>();
            context.Database.EnsureCreated();
            var userManager = serviceProvider.GetService<UserManager<Employee>>();
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();

            if (!context.Users.Any())
            {
                string[] roles = new string[] { "Admin", "Employee" };
                foreach (string role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new ApplicationRole(role));
                    }
                }

                List<Employee> users = new List<Employee>() {
                    new Employee {
                        Id = IDs[1, 0],
                        UserName = "Employee",
                        EmailConfirmed = true,
                        Name = "Mikaela",
                        Surname = "Gomis",
                        Email = "mikaelagomis@ittaca.com",
                        Hired = new DateTime(2018, 9, 15),
                        Salary = 31560.56,
                        Position = "Attendant"
                    },
                    new Employee {
                        Id = IDs[1, 1],
                        UserName = "kevingarcia@ittaca.com",
                        EmailConfirmed = true,
                        Name = "Kevin",
                        Surname = "Garcia",
                        Email = "kevingarcia@ittaca.com",
                        Hired = new DateTime(2015, 5, 23),
                        Salary = 31560.56,
                        Position = "Attendant"
                    },
                    new Employee {
                        Id = IDs[1, 2],
                        UserName = "Admin",
                        EmailConfirmed = true,
                        Name = "Joan",
                        Surname = "Cot",
                        Email = "joancot@ittaca.com",
                        Hired = new DateTime(2019, 10, 5),
                        Salary = 63810.13,
                        Position = "Manager"
                    },
                };

                foreach (Employee user in users)
                {
                    await userManager.CreateAsync(user, "Pass123$");

                    if (user.Position == "Manager")
                        await userManager.AddToRoleAsync(user, "Admin");
                    else
                        await userManager.AddToRoleAsync(user, "Employee");
                }
                context.SaveChanges();
            }
        }
    }
}