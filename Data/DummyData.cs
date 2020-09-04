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
    /*
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ERPContext>();
                context.Database.EnsureCreated();

                // Look for any events
                if (context.Products != null && context.Products.Any())
                    return;

                var products = GetProducts().ToArray();
                context.Products.AddRange(products);
                context.SaveChanges();

                var employees = GetEmployees().ToArray();
                context.Users.AddRange(employees);
                context.SaveChanges();

                var customers = GetCustomers().ToArray();
                context.Customers.AddRange(customers);
                context.SaveChanges();

                var orders = GetOrders().ToArray();
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
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

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>() {
                new User {
                    Name = "Gerard",
                    Surname = "Ferrer",
                    Email = "gf@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                },
                new User {
                    Name = "Oriol",
                    Surname = "Muñiz",
                    Email = "om@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                },
                new User {
                    Name = "Francisco Javier",
                    Surname = "Rivas",
                    Email = "fjr@gmail.com",
                    Type = "student",
                    IdItinerary = 6
                }
            };
            return users;
        }

        public static List<Attendee> GetAttendees()
        {
            List<Attendee> attendees = new List<Attendee>() {
                new Attendee {
                    IdEvent = 1,
                    IdStudent = 1
                },
                new Attendee {
                    IdEvent = 2,
                    IdStudent = 2,
                    Accepted = true
                },
                new Attendee {
                    IdEvent = 2,
                    IdStudent = 3,
                    Accepted = true
                },
            };
            return attendees;
        }
    }
    */
}
