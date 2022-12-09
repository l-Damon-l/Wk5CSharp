using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NorthwindData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData;

internal class MiniProjectMethodSyntax
{
    internal static void Main(string[] args) {
        //Exercise1dot1();
        //Exercise1dot2();
        //Exercise1dot3Join();
        //Exercise1dot3Includes();
        //Exercise1dot4Join();
        //Exercise1dot4Includes();
        //Exercise1dot5();
        //Exercise1dot6();
        //Exercise1dot7();
        //Exercise1dot8();
    }

    internal static void Exercise1dot1() {
        using var db = new NorthwindContext();
        var parisOrLondon = db.Customers
            .Select(c => new {
                c.CustomerId,
                c.CompanyName,
                c.Address,
                c.City,
                c.PostalCode,
                c.Country
            })
            .Where(c => c.City == "Paris" || c.City == "London");
        foreach (var customer in parisOrLondon) {
            Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.CompanyName}, Address: {customer.Address}, City: {customer.City}, " +
                $"Postal Code: {customer.PostalCode}, Country: {customer.Country}");
        }
    }

    internal static void Exercise1dot2() {
        using var db = new NorthwindContext();
        var bottleProducts = db.Products
            .Select(p => new { p.ProductName, p.QuantityPerUnit })
            .Where(p => p.QuantityPerUnit != null && p.QuantityPerUnit.Contains("bottle"));
        foreach (var product in bottleProducts) {
            Console.WriteLine($"Name: {product.ProductName}, Quantity Per Unit: {product.QuantityPerUnit}");
        }
    }

    internal static void Exercise1dot3Join() {
        using var db = new NorthwindContext();
        var bottleProducts = db.Products
            .Select(p => new { p.ProductName, p.QuantityPerUnit, p.SupplierId })
            .Join(db.Suppliers, p => p.SupplierId, s => s.SupplierId, (p, s) => new { p.ProductName, p.QuantityPerUnit, s.CompanyName, s.Country })
            .Where(p => p.QuantityPerUnit != null && p.QuantityPerUnit.Contains("bottle"));
        foreach (var product in bottleProducts) {
            Console.WriteLine($"Name: {product.ProductName}, Quantity Per Unit: {product.QuantityPerUnit}, " +
                $"Company name: {product.CompanyName}, Country: {product.Country}");
        }
    }

    internal static void Exercise1dot3Includes() {
        using var db = new NorthwindContext();
        var bottleProducts = db.Products
            .Include(p => p.Supplier)
            .Select(p => new { p.ProductName, p.QuantityPerUnit, p.SupplierId, p.Supplier.CompanyName, p.Supplier.Country })
            .Where(p => p.QuantityPerUnit != null && p.QuantityPerUnit.Contains("bottle"));
        foreach (var product in bottleProducts) {
            Console.WriteLine($"Name: {product.ProductName}, Quantity Per Unit: {product.QuantityPerUnit}, " +
                $"Company name: {product.CompanyName}, Country: {product.Country}");
        }
    }

    internal static void Exercise1dot4Join() {
        using var db = new NorthwindContext();
        var categories = db.Products
            .Select(p => new { p.ProductName, p.CategoryId })
            .Join(db.Categories, p => p.CategoryId, c => c.CategoryId, (p, c) => new { p.ProductName, c.CategoryName })
            .GroupBy(p => p.CategoryName)
            .Select(p => new { CategoryName = p.Key, Count = p.Count() })
            .OrderByDescending(p => p.Count);
        foreach (var category in categories) {
            Console.WriteLine($"Category name: {category.CategoryName}, " +
                $"No of Products: {category.Count}");
        }
    }

    internal static void Exercise1dot4Includes() {
        using var db = new NorthwindContext();
        var categories = db.Products
            .Include(p => p.Category)
            .GroupBy(p => p.Category.CategoryName)
            .Select(p => new { CategoryName = p.Key, Count = p.Count() })
            .OrderByDescending(p => p.Count);
        foreach (var category in categories) {
            Console.WriteLine($"Category name: {category.CategoryName}, " +
                $"No of Products: {category.Count}");
        }
    }

    internal static void Exercise1dot5() {
        using var db = new NorthwindContext();
        var employees = db.Employees
            .Where(e => e.Country == "UK")
            .Select(e => new {
                FullName = e.TitleOfCourtesy + " " + e.FirstName + " " + e.LastName,
                City = e.City
            });
        foreach (var employee in employees) {
            Console.WriteLine($"Name: {employee.FullName}, City: {employee.City}");
        }
    }

    internal static void Exercise1dot6() {
        using var db = new NorthwindContext();
        var count = db.Orders
            .Where(o => o.Freight > 100.00m)
            .Where(o => o.ShipCountry == "USA" || o.ShipCountry == "UK")
            .Count();
        Console.WriteLine($"No of Orders >100 from US or UK: {count}");
    }

    internal static void Exercise1dot7() {
        // This is stupid, but it works
        using var db = new NorthwindContext();
        var ordersWithLargestDiscount = db.Orders
            .Join(db.OrderDetails, o => o.OrderId, od => od.OrderId, (o, od) => new {
                o.OrderId,
                od.UnitPrice,
                od.Quantity,
                od.Discount
            })
            .Select(o => new {
                o.OrderId,
                TotalDiscount = o.UnitPrice * (decimal)o.Quantity * (decimal)o.Discount,
                TotalDiscountDollars = (o.UnitPrice * (decimal)o.Quantity * (decimal)o.Discount).ToString("C")
            })
            .Where(o => o.TotalDiscount == db.Orders
                .Join(db.OrderDetails, o => o.OrderId, od => od.OrderId, (o, od) => new {
                    o.OrderId,
                    od.UnitPrice,
                    od.Quantity,
                    od.Discount
                })
                .Select(o => new {
                    OrderId = o.OrderId,
                    TotalDiscount = o.UnitPrice * o.Quantity * (decimal)o.Discount
                })
                .Max(o => o.TotalDiscount));
        foreach (var o in ordersWithLargestDiscount) {
            Console.WriteLine($"ID: {o.OrderId}, Discount: {o.TotalDiscountDollars}");
        }
    }

    internal static void Exercise1dot8() {
        using var db = new NorthwindContext();
        var employees = db.Employees
            .Join(db.Employees, e => e.ReportsTo, e2 => e2.EmployeeId, (e, e2) => new {
                EmployeeName = e.FirstName + " " + e.LastName,
                ReportsToName = e2.FirstName + " " + e2.LastName
            })
            .OrderBy(e => e.ReportsToName)
            .ThenBy(e => e.EmployeeName);
        foreach (var employee in employees) {
            Console.WriteLine($"Name: {employee.EmployeeName}, " +
                $"Reports to: {employee.ReportsToName}");
        }
    }
}
