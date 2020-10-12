using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstPurchase = table.Column<DateTime>(nullable: false),
                    LatestPurchase = table.Column<DateTime>(nullable: false),
                    TotalExpenditure = table.Column<double>(nullable: false),
                    TotalPurchases = table.Column<int>(nullable: false),
                    DeliveryAddress = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Hired = table.Column<DateTime>(nullable: false),
                    Departed = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<long>(nullable: false),
                    IdProduct = table.Column<long>(nullable: false),
                    IdEmployee = table.Column<long>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PriceVAT = table.Column<double>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    ExpectedDelivery = table.Column<DateTime>(nullable: false),
                    Delivered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Purchases = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
