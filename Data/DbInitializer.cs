using ERPProject.Models;
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
        static readonly Guid[,] IDs = new Guid[3, 10];
        
        static DbInitializer()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    IDs[i, j] = Guid.NewGuid();
                }
            }
        }

        public static async Task Initialize(IServiceProvider serviceProvider)
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
                    Name = "Earbuds 100X",
                    Category = "Electronics",
                    Description = "The best earbuds on the market!",
                    CurrentPrice = 17.99,
                    Stock = 4500,
                    Purchases = 102
                },
                new Product {
                    Id = IDs[0, 1],
                    Name = "Blue shirt",
                    Category = "Men's Shirts",
                    Description = "A top-quality cotton shirt, in blue",
                    CurrentPrice = 20.49,
                    Stock = 1200,
                    Purchases = 323
                },
                new Product {
                    Id = IDs[0, 2],
                    Name = "The Handmaid's Tale",
                    Category = "Books",
                    Description = "#1 New York Times bestseller. Look for The Testaments, the sequel to The Handmaid’s Tale, available now. An instant classic and eerily prescient cultural phenomenon, from “the patron saint of feminist dystopian fiction” (New York Times).Now an award-winning Hulu series starring Elizabeth Moss. In Margaret Atwood’s dystopian future, environmental disasters and declining birthrates have led to a Second American Civil War.The result is the rise of the Republic of Gilead, a totalitarian regime that enforces rigid social roles and enslaves the few remaining fertile women. Offred is one of these, a Handmaid bound to produce children for one of Gilead’s commanders.Deprived of her husband, her child, her freedom, and even her own name, Offred clings to her memories and her will to survive.At once a scathing satire, an ominous warning, and a tour de force of narrative suspense, The Handmaid’s Tale is a modern classic. Includes an introduction by Margaret Atwood. Paperback – March 16, 1998",
                    CurrentPrice = 7.99,
                    Stock = 3004,
                    Purchases = 2809
                },
                new Product {
                    Id = IDs[0, 3],
                    Name = "Makeup Remover Cleansing Face Wipes, Daily Cleansing Facial Towelettes to Remove Waterproof Makeup and Mascara, Alcohol-Free, Value Twin Pack, 25 Count, 2 Pack",
                    Category = "Skin Care",
                    Description = "Remove makeup in one easy step with Makeup Remover Cleansing Face Wipes. These soft and gentle pre-moistened facial cleansing towelettes effectively dissolve all traces of dirt, oil and makeup—even waterproof mascara— for clean, fresh looking skin every day. Our waterproof makeup remover wipes feature an effective formula that leaves skin thoroughly clean with no heavy residue, so there's no need to rinse. Designed to also remove eye makeup, these daily face wipes are formulated to be gentle on the eyes and are suitable for contact lens wearers as part of their daily at-home skincare routine. Neutrogena Cleansing Facial Towelettes are free of alcohol and are also ophthalmologist-, dermatologist-, and allergy-tested.",
                    CurrentPrice = 8.97,
                    Stock = 980,
                    Purchases = 401
                },
                new Product {
                    Id = IDs[0, 4],
                    Name = "Nuby Ice Gel Teether Keys",
                    Category = "Baby & Toddler Toys",
                    Description = "Nuby Ice Gel Teether Keys Nuby Ice Gel Teether Keys contains nontoxic purIce gel that lets it stay cool for a long time. Its cool textured surface soothes and stimulates sore gums. The teething nubs can help massage tender gums. The bright colorful shapes stimulate your baby visually and also help with eye-hand coordination. Age: 3 months and up Features Helps in eye hand coordination Bright and colorful shapes Teething nubs help massage tender gums Textured surface soothes and stimulates sore gums Contains nontoxic purIce gel Stays cool for long time Durable Product. For sore gums, the cool resilient bottom part of the \"keys\" soothes and stimulates safely",
                    CurrentPrice = 3.88,
                    Stock = 315,
                    Purchases = 32
                },
                new Product {
                    Id = IDs[0, 5],
                    Name = "Ecolution Original Microwave Micro-Pop Popcorn Popper, Borosilicate Glass, 3-in-1 Silicone Lid, Dishwasher Safe, BPA Free, 1.5 Quart - Snack Size, Red",
                    Category = "Kitchen & Dining",
                    Description = "Ecolution Original Microwave Micro-Pop Popcorn Popper, Borosilicate Glass, 3-in-1 Silicone Lid, Dishwasher Safe, BPA Free, 1.5 Quart - Snack Size, Red.",
                    CurrentPrice = 12.99,
                    Stock = 300,
                    Purchases = 59
                },
                new Product {
                    Id = IDs[0, 6],
                    Name = "Nano Light Miniature Keychain LED Flashlight, Black - 10 Lumens",
                    Category = "Camping & Hiking",
                    Description = "Truly tiny, the Nano Light is a weatherproof, personal flashlight featuring a 100,000 hour life LED. Includes a non rotating snap hook for easy one handed operation when attached to a keychain. Easily attaches/detaches to just about anything with convenient pocket clip or key ring. Up to 8 hours run time. Machined aircraft grade aluminum with anodized finish. Powered by 4 alkaline button cells (included). 100,000 hour lifetime high intensity LED. LED available in white (10 lumens). 1.47 Inch x 0.51 Inch, 0.36 oz. Available in black.",
                    CurrentPrice = 5.09,
                    Stock = 180,
                    Purchases = 78
                },
                new Product {
                    Id = IDs[0, 7],
                    Name = "2-Pack 60W Equivalent Dimmable LED Smart Bulbs (Hue Hub Required, Works with Alexa, HomeKit & Google Assistant)",
                    Category = "Industrial Electrical",
                    Description = "This 2-Pack of Smart Bulbs allows you to automate your smart lights for peace of mind. Add a white bulbs to your lighting system and enhance your smart home with soft white lighting that you can dim and control remotely using our app. Automate your lights to make it seem like you’re home when you’re not or set timers.",
                    CurrentPrice = 29.96,
                    Stock = 60,
                    Purchases = 67
                },
                new Product {
                    Id = IDs[0, 8],
                    Name = "Dog Hair Remover, Cat Hair Remover, Pet Hair Remover",
                    Category = "Pet Supplies",
                    Description = "The World’s Best Pet Hair Remover. By simply moving the pet hair roller back and forth, you immediately track and pick up cat hairs and dog hairs embedded deeply in sofas, couches, beds, carpets, blankets, comforters and more. You have probably tried all types of pet hair and lint removal products… from sticky roller tapes, to products that cannot be used over and over again. With the World’s Best Pet Hair Remover, you'll never need another gadget! No adhesive or sticky tape, 100% reusable, no power source required, clean and convenient pet hair remover. They make great gifts!",
                    CurrentPrice = 24.95,
                    Stock = 110,
                    Purchases = 85
                },
                new Product {
                    Id = IDs[0, 9],
                    Name = "The 2-Hour Job Search, Second Edition: Using Technology to Get the Right Job Faster",
                    Category = "Business & Money",
                    Description = "Use the latest technology to target potential employers and secure the first interview--no matter your experience, education, or network--with these revised and updated tools and recommendations. “The most practical, stress-free guide ever written for finding a white-collar job.”—Dan Heath, coauthor of Switch and Made to Stick",
                    CurrentPrice = 9.68,
                    Stock = 40,
                    Purchases = 24
                }
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
                    Email = "nuriarossi@example.com",
                    FirstPurchase = new DateTime(2014, 6, 1, 18, 17, 53),
                    LatestPurchase = new DateTime(2020, 9, 28, 11, 45, 12),
                    TotalExpenditure = 568.33,
                    TotalPurchases = 41,
                    DeliveryAddress = "C/ Enxertos 85, Monsagro, Salamanca, 37532, Spain",
                    BillingAddress = "C/ Enxertos 85, Monsagro, Salamanca, 37532, Spain",
                    BankAccount = "ES9121000418450200051332"
                },
                new Customer {
                    Id = IDs[2, 1],
                    Name = "Hector",
                    Surname = "Roca",
                    Email = "hectorroca@example.com",
                    FirstPurchase = new DateTime(2013, 3, 23, 22, 42, 11),
                    LatestPurchase = new DateTime(2020, 11, 11, 18, 10, 24),
                    TotalExpenditure = 445.65,
                    TotalPurchases = 29,
                    DeliveryAddress = "C/ Pascual Yunquera 40, Cortes de Baza, Granada, 18814, Spain",
                    BillingAddress = "C/ Pascual Yunquera 40, Cortes de Baza, Granada, 18814, Spain",
                    BankAccount = "ES4031907163513548452719"
                },
                new Customer {
                    Id = IDs[2, 2],
                    Name = "Alex",
                    Surname = "Perez",
                    Email = "alexperez@example.com",
                    FirstPurchase = new DateTime(2017, 1, 29, 9, 9, 55),
                    LatestPurchase = new DateTime(2020, 9, 2, 20, 19, 1),
                    TotalExpenditure = 2899.09,
                    TotalPurchases = 88,
                    DeliveryAddress = "C/ Cuevas de Ambrosio 72, León, León, 24000, Spain",
                    BillingAddress = "C/ Extramuros 11, Valdemoro, Madrid, 28340, Spain",
                    BankAccount = "ES7701824756598176787587"
                },
                new Customer {
                    Id = IDs[2, 3],
                    Name = "Frida",
                    Surname = "Lamb",
                    Email = "fridalamb@example.com",
                    FirstPurchase = new DateTime(2016, 5, 18, 20, 20, 38),
                    LatestPurchase = new DateTime(2020, 8, 1, 10, 13, 42),
                    TotalExpenditure = 430.88,
                    TotalPurchases = 28,
                    DeliveryAddress = "C/ Canarias 79, Zizurkil, Guipúzcoa, 20159, Spain",
                    BillingAddress = "C/ Canarias 79, Zizurkil, Guipúzcoa, 20159, Spain",
                    BankAccount = "ES5370097603241223155858"
                },
                new Customer {
                    Id = IDs[2, 4],
                    Name = "Bai",
                    Surname = "Yu",
                    Email = "yubai@example.com",
                    FirstPurchase = new DateTime(2017, 3, 22, 18, 41, 12),
                    LatestPurchase = new DateTime(2020, 7, 25, 10, 43, 50),
                    TotalExpenditure = 417.41,
                    TotalPurchases = 15,
                    DeliveryAddress = "C/ Atamaria 90, Pazos de Borbén, Pontevedra, 36841, Spain",
                    BillingAddress = "C/ Atamaria 90, Pazos de Borbén, Pontevedra, 36841, Spain",
                    BankAccount = "ES1070423976265825901836"
                },
                new Customer {
                    Id = IDs[2, 5],
                    Name = "Ruth",
                    Surname = "Bach",
                    Email = "ruthbach@example.com",
                    FirstPurchase = new DateTime(2018, 4, 12, 14, 2, 39),
                    LatestPurchase = new DateTime(2020, 11, 5, 9, 35, 20),
                    TotalExpenditure = 860.75,
                    TotalPurchases = 11,
                    DeliveryAddress = "C/ Angosto 36, Cazorla, Jaén, 23470, Spain",
                    BillingAddress = "C/ Angosto 36, Cazorla, Jaén, 23470, Spain",
                    BankAccount = "ES4817714191298170553409"
                },
                new Customer {
                    Id = IDs[2, 6],
                    Name = "Pere",
                    Surname = "Ruiz",
                    Email = "pereruiz@example.com",
                    FirstPurchase = new DateTime(2018, 10, 6, 20, 24, 39),
                    LatestPurchase = new DateTime(2020, 8, 24, 12, 11, 40),
                    TotalExpenditure = 268.25,
                    TotalPurchases = 8,
                    DeliveryAddress = "C/ Canónigo Valiño 21, Albal, Valencia, 46470, Spain",
                    BillingAddress = "C/ Canónigo Valiño 21, Albal, Valencia, 46470, Spain",
                    BankAccount = "ES5516576032354042084084"
                },
                new Customer {
                    Id = IDs[2, 7],
                    Name = "Mbaye",
                    Surname = "Diouf",
                    Email = "mbayediouf@example.com",
                    FirstPurchase = new DateTime(2015, 12, 23, 21, 22, 2),
                    LatestPurchase = new DateTime(2020, 10, 4, 14, 5, 38),
                    TotalExpenditure = 136.19,
                    TotalPurchases = 12,
                    DeliveryAddress = "C/ Bouciña 63, Roda de Barà, Tarragona, 43883, Spain",
                    BillingAddress = "C/ Bouciña 63, Roda de Barà, Tarragona, 43883, Spain",
                    BankAccount = "ES0258247624593984351978"
                },
                new Customer {
                    Id = IDs[2, 8],
                    Name = "Hamid",
                    Surname = "Sabir",
                    Email = "hamidsabir@example.com",
                    FirstPurchase = new DateTime(2019, 1, 4, 22, 21, 31),
                    LatestPurchase = new DateTime(2020, 7, 2, 14, 41, 29),
                    TotalExpenditure = 632.49,
                    TotalPurchases = 11,
                    DeliveryAddress = "C/ Castelao 67, Galdakao, Biscay, 48960, Spain",
                    BillingAddress = "C/ Castelao 67, Galdakao, Biscay, 48960, Spain",
                    BankAccount = "ES0289894972523441317126"
                },
                new Customer {
                    Id = IDs[2, 9],
                    Name = "Bill",
                    Surname = "Gates",
                    Email = "billgates@outlook.com",
                    FirstPurchase = new DateTime(2019, 9, 5, 9, 27, 14),
                    LatestPurchase = new DateTime(2020, 9, 7, 14, 16, 42),
                    TotalExpenditure = 2632.48,
                    TotalPurchases = 229,
                    DeliveryAddress = "C/ Seattle 1, Sant Cugat del Vallès, Barcelona, 08197, Spain",
                    BillingAddress = "C/ Seattle 1, Sant Cugat del Vallès, Barcelona, 08197, Spain",
                    BankAccount = "ES1580345837865106595855"
                }
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
                    Time = new DateTime(2020, 9, 28, 11, 45, 12),
                    Quantity = 1,
                    Price = 14.87,
                    PriceVAT = 17.99,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 10, 1),
                    Delivered = new DateTime(2020, 10, 1, 15, 32, 59)
                },
                new Order {
                    CustomerId = IDs[2, 0],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 3],
                    Time = new DateTime(2020, 6, 1, 18, 11, 3),
                    Quantity = 1,
                    Price = 7.41,
                    PriceVAT = 8.97,
                    State = "Canceled",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 6, 3),
                    Delivered = null
                },
                new Order {
                    CustomerId = IDs[2, 0],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 7],
                    Time = new DateTime(2020, 6, 2, 18, 11, 3),
                    Quantity = 1,
                    Price = 24.76,
                    PriceVAT = 29.96,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 6, 5),
                    Delivered = new DateTime(2020, 6, 5, 13, 43, 15),
                },
                new Order {
                    CustomerId = IDs[2, 1],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 1],
                    Time = new DateTime(2020, 11, 11, 18, 10, 24),
                    Quantity = 1,
                    Price = 16.93,
                    PriceVAT = 20.49,
                    State = "Delivered",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 11, 12),
                    Delivered = new DateTime(2020, 11, 12, 16, 11, 34)
                },
                new Order {
                    CustomerId = IDs[2, 1],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 6],
                    Time = new DateTime(2020, 11, 7, 13, 17, 57),
                    Quantity = 2,
                    Price = 8.41,
                    PriceVAT = 10.18,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 11, 9),
                    Delivered = new DateTime(2020, 11, 10, 10, 27, 30)
                },
                new Order {
                    CustomerId = IDs[2, 2],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 2],
                    Time = new DateTime(2020, 9, 2, 20, 19, 1),
                    Quantity = 1,
                    Price = 7.68,
                    PriceVAT = 7.99,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 9, 3),
                    Delivered = new DateTime(2020, 9, 3, 12, 10, 3)
                },
                new Order {
                    CustomerId = IDs[2, 2],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 4],
                    Time = new DateTime(2020, 11, 23, 22, 6, 33),
                    Quantity = 1,
                    Price = 3.21,
                    PriceVAT = 3.88,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 11, 24),
                    Delivered = new DateTime(2020, 11, 24, 17, 4, 25)
                },
                new Order {
                    CustomerId = IDs[2, 3],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 7],
                    Time = new DateTime(2020, 8, 1, 10, 13, 42),
                    Quantity = 1,
                    Price = 24.76,
                    PriceVAT = 29.96,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 8, 4),
                    Delivered = new DateTime(2020, 8, 4, 11, 59, 0)
                },
                new Order {
                    CustomerId = IDs[2, 3],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 4],
                    Time = new DateTime(2020, 6, 11, 13, 36, 36),
                    Quantity = 1,
                    Price = 3.21,
                    PriceVAT = 3.88,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 6, 12),
                    Delivered = new DateTime(2020, 6, 12, 12, 13, 22)
                },
                new Order {
                    CustomerId = IDs[2, 3],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 3],
                    Time = new DateTime(2020, 10, 8, 22, 46, 49),
                    Quantity = 1,
                    Price = 7.68,
                    PriceVAT = 7.99,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 10, 9),
                    Delivered = new DateTime(2020, 10, 9, 17, 56, 49)
                },
                new Order {
                    CustomerId = IDs[2, 4],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 1],
                    Time = new DateTime(2020, 7, 25, 17, 56, 35),
                    Quantity = 1,
                    Price = 16.93,
                    PriceVAT = 20.49,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 7, 29),
                    Delivered = new DateTime(2020, 7, 30, 12, 19, 23)
                },
                new Order {
                    CustomerId = IDs[2, 4],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 7],
                    Time = new DateTime(2020, 6, 5, 21, 50, 40),
                    Quantity = 1,
                    Price = 24.76,
                    PriceVAT = 29.96,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 6, 9),
                    Delivered = new DateTime(2020, 6, 9, 13, 0, 7)
                },
                new Order {
                    CustomerId = IDs[2, 4],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 2],
                    Time = new DateTime(2020, 10, 19, 15, 26, 33),
                    Quantity = 1,
                    Price = 7.68,
                    PriceVAT = 7.99,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 10, 21),
                    Delivered = new DateTime(2020, 10, 21, 16, 57, 34)
                },
                new Order {
                    CustomerId = IDs[2, 5],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 6],
                    Time = new DateTime(2020, 11, 5, 9, 35, 20),
                    Quantity = 1,
                    Price = 4.21,
                    PriceVAT = 5.09,
                    State = "Delivered",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 11, 10),
                    Delivered = new DateTime(2020, 11, 10, 14, 38, 6)
                },
                new Order {
                    CustomerId = IDs[2, 5],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 3],
                    Time = new DateTime(2020, 9, 6, 21, 39, 38),
                    Quantity = 1,
                    Price = 7.41,
                    PriceVAT = 8.97,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 9, 7),
                    Delivered = new DateTime(2020, 9, 7, 17, 32, 57)
                },
                new Order {
                    CustomerId = IDs[2, 5],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 9],
                    Time = new DateTime(2020, 11, 4, 15, 51, 25),
                    Quantity = 1,
                    Price = 9.31,
                    PriceVAT = 9.68,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 11, 5),
                    Delivered = new DateTime(2020, 11, 5, 13, 46, 28)
                },
                new Order {
                    CustomerId = IDs[2, 6],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 7],
                    Time = new DateTime(2020, 8, 24, 12, 11, 40),
                    Quantity = 1,
                    Price = 24.76,
                    PriceVAT = 29.96,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 8, 28),
                    Delivered = new DateTime(2020, 8, 28, 15, 17, 51)
                },
                new Order {
                    CustomerId = IDs[2, 6],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 9],
                    Time = new DateTime(2020, 10, 3, 17, 48, 52),
                    Quantity = 1,
                    Price = 9.31,
                    PriceVAT = 9.68,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 10, 7),
                    Delivered = new DateTime(2020, 10, 7, 10, 10, 31)
                },
                new Order {
                    CustomerId = IDs[2, 7],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 5],
                    Time = new DateTime(2020, 10, 4, 14, 5, 38),
                    Quantity = 1,
                    Price = 10.74,
                    PriceVAT = 12.99,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 10, 6),
                    Delivered = new DateTime(2020, 10, 7, 13, 3, 43)
                },
                new Order {
                    CustomerId = IDs[2, 7],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 8],
                    Time = new DateTime(2020, 7, 16, 18, 48, 29),
                    Quantity = 1,
                    Price = 20.62,
                    PriceVAT = 24.95,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 7, 17),
                    Delivered = new DateTime(2020, 7, 17, 13, 31, 5)
                },
                new Order {
                    CustomerId = IDs[2, 7],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 9],
                    Time = new DateTime(2020, 9, 6, 12, 09, 28),
                    Quantity = 1,
                    Price = 9.31,
                    PriceVAT = 9.68,
                    State = "Delivered",
                    Priority = 2,
                    ExpectedDelivery = new DateTime(2020, 9, 7),
                    Delivered = new DateTime(2020, 9, 7, 12, 21, 14)
                },
                new Order {
                    CustomerId = IDs[2, 8],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 4],
                    Time = new DateTime(2020, 7, 2, 14, 41, 29),
                    Quantity = 1,
                    Price = 3.21,
                    PriceVAT = 3.88,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 7, 6),
                    Delivered = new DateTime(2020, 7, 6, 15, 29, 42)
                },
                new Order {
                    CustomerId = IDs[2, 8],
                    EmployeeId = IDs[1, 1],
                    ProductId = IDs[0, 0],
                    Time = new DateTime(2020, 6, 10, 13, 14, 53),
                    Quantity = 1,
                    Price = 14.87,
                    PriceVAT = 17.99,
                    State = "Delivered",
                    Priority = 3,
                    ExpectedDelivery = new DateTime(2020, 6, 15),
                    Delivered = new DateTime(2020, 6, 15, 19, 8, 41)
                },
                new Order {
                    CustomerId = IDs[2, 9],
                    EmployeeId = IDs[1, 2],
                    ProductId = IDs[0, 8],
                    Time = new DateTime(2020, 9, 7, 14, 16, 42),
                    Quantity = 1,
                    Price = 20.62,
                    PriceVAT = 24.95,
                    State = "Canceled",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 9, 10),
                    Delivered = null
                },
                new Order {
                    CustomerId = IDs[2, 9],
                    EmployeeId = IDs[1, 0],
                    ProductId = IDs[0, 5],
                    Time = new DateTime(2020, 7, 21, 14, 29, 33),
                    Quantity = 1,
                    Price = 10.74,
                    PriceVAT = 12.99,
                    State = "Delivered",
                    Priority = 1,
                    ExpectedDelivery = new DateTime(2020, 7, 22),
                    Delivered = new DateTime(2020, 7, 22, 11, 43, 48)
                }
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
