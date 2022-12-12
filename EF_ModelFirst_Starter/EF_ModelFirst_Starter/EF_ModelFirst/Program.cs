using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args) {
            using (var db = new SouthwindContext()) {
                SeedDb(db);
                var consoleApp = new CustomerManagerConsole(db);
                consoleApp.MainLoop();
            }
        }

        private static void SeedDb(SouthwindContext db) {
            SeedCustomerDb(db);
            SeedOrderDb(db);
            SeedOrderDetailsDb(db);
            SeedSuppliersDb(db);
        }
        private static void SeedCustomerDb(SouthwindContext db) {
            // Delete all entries in db.Customers
            db.Customers.RemoveRange(db.Customers);

            var customerList = new List<Customer>() {
                new Customer() {
                    CustomerId = "key1",
                    ContactName = "Jim Jimmy",
                    City = "London",
                    PostalCode = "12345",
                    Country = "UK"
                },
                new Customer() {
                    CustomerId = "key2",
                    ContactName = "Dave Davis",
                    City = "Birmingham",
                    PostalCode = "45748",
                    Country = "UK"
                },
                new Customer() {
                    CustomerId = "key3",
                    ContactName = "Mary Maria",
                    City = "Leeds",
                    PostalCode = "34567",
                    Country = "UK"
                },
                new Customer() {
                    CustomerId = "key4",
                    ContactName = "Maria Mary",
                    City = "Portsmouth",
                    PostalCode = "38746",
                    Country = "UK"
                },
                new Customer() {
                    CustomerId = "key5",
                    ContactName = "Jamie Jamerson",
                    City = "Hull",
                    PostalCode = "34762",
                    Country = "UK"
                },
                new Customer() {
                    CustomerId = "key6",
                    ContactName = "Jacque Pépin",
                    City = "Paris",
                    PostalCode = "89764",
                    Country = "France"
                },
                new Customer() {
                    CustomerId = "key7",
                    ContactName = "Sophie Marceau",
                    City = "Paris",
                    PostalCode = "83453",
                    Country = "France"
                },
                new Customer() {
                    CustomerId = "key8",
                    ContactName = "Sadako Yamamura",
                    City = "Tokyo",
                    PostalCode = "76443",
                    Country = "Japan"
                }
            };
            db.AddRange(customerList);
            db.SaveChanges();
        }
        private static void SeedOrderDb(SouthwindContext db) {
            // Delete all entries in db.Orders
            db.Orders.RemoveRange(db.Orders);
            // Reset the auto-incrementing ID
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.Orders', RESEED, 0);");  // Reset the Identity (OrderId) to 1
            var orderArray = new Order[] {
                new Order {
                    CustomerId = "key1",
                    OrderDate = new DateTime(2020, 1, 1),
                    ShippedDate = new DateTime(2020, 1, 2),
                    ShipCountry = "UK"
                },
                new Order {
                    CustomerId = "key4",
                    OrderDate = new DateTime(2020, 2, 20),
                    ShippedDate = new DateTime(2020, 2, 22),
                    ShipCountry = "UK"
                },
                new Order {
                    CustomerId = "key3",
                    OrderDate = new DateTime(2020, 2, 18),
                    ShippedDate = new DateTime(2020, 2, 21),
                    ShipCountry = "UK"
                },
                new Order {
                    CustomerId = "key2",
                    OrderDate = new DateTime(2020, 2, 21),
                    ShippedDate = new DateTime(2020, 2, 23),
                    ShipCountry = "China"
                },
                new Order {
                    CustomerId = "key3",
                    OrderDate = new DateTime(2020, 3, 2),
                    ShippedDate = new DateTime(2020, 3, 3),
                    ShipCountry = "Germany"
                },
            };
            db.Orders.AddRange(orderArray);
            db.SaveChanges();
        }
        private static void SeedOrderDetailsDb(SouthwindContext db) {
            // Delete all entries in db.OrderDetails
            db.OrderDetails.RemoveRange(db.OrderDetails);
            // Reset the auto-incrementing ID
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.OrderDetails', RESEED, 0);");
            var detailsArray = new[] {
                new OrderDetail{
                    OrderId = 1,
                    UnitPrice = 9.99m,
                    Quantity = 1,
                    Discount = 0.0f
                },
                new OrderDetail{
                    OrderId = 2,
                    UnitPrice = 11.99m,
                    Quantity = 2,
                    Discount = 0.1f
                },
                new OrderDetail{
                    OrderId = 3,
                    UnitPrice = 4.99m,
                    Quantity = 5,
                    Discount = 0.2f
                },
                new OrderDetail{
                    OrderId = 4,
                    UnitPrice = 49.99m,
                    Quantity = 1,
                    Discount = 0.0f
                },
                new OrderDetail{
                    OrderId = 5,
                    UnitPrice = 129.99m,
                    Quantity = 1,
                    Discount = 0.1f
                }
            };
            db.OrderDetails.AddRange(detailsArray);
            db.SaveChanges();
        }
        private static void SeedSuppliersDb(SouthwindContext db) {
            // Delete all entries in db.OrderDetails
            db.Suppliers.RemoveRange(db.Suppliers);
            // Reset the auto-incrementing ID
            db.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.Suppliers', RESEED, 0);");
            var suppliersArray = new[] {
                new Supplier {
                    CompanyName = "UK Supplier 1",
                    City = "London",
                    Country = "UK",
                    OrderDetailId = 3,
                },
                new Supplier {
                    CompanyName = "UK Supplier 2",
                    City = "Oxford",
                    Country = "UK",
                    OrderDetailId = 3,
                },
                new Supplier {
                    CompanyName = "UK Supplier 3",
                    City = "Manchester",
                    Country = "UK",
                    OrderDetailId = 1,
                },
                new Supplier {
                    CompanyName = "UK Supplier 4",
                    City = "Leeds",
                    Country = "UK",
                    OrderDetailId = 2,
                },
                new Supplier {
                    CompanyName = "German Supplier 1",
                    City = "Dusseldorf",
                    Country = "Germany",
                    OrderDetailId = 4,
                },
                new Supplier {
                    CompanyName = "German Supplier 1",
                    City = "Berlin",
                    Country = "Germany",
                    OrderDetailId = 5,
                },
            };
            db.Suppliers.AddRange(suppliersArray);
            db.SaveChanges();
        }
    }
}


