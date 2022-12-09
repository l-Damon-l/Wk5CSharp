// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using NorthwindData;
using NorthwindData.Models;
using System.Reflection.Metadata.Ecma335;

#region EF Lesson
//using (var db = new NorthwindContext()) {
//foreach (var customer in db.Customers) {
//    Console.WriteLine(
//        $"Customer {customer.ContactName} " +
//        $"has ID {customer.CustomerId} " +
//        $"and lives in {customer.City}"
//    );
//}

//var newCustomer = new Customer {
//    CustomerId = "BLOGG",
//    ContactName = "Joe Bloggs",
//    CompanyName = "ToysRUs"
//};

//db.Customers.Add(newCustomer);
//db.SaveChanges();

//var selectedCustomer = db.Customers.Find("BLOGG");
//Console.WriteLine(selectedCustomer);

//selectedCustomer.City = "Paris";
//db.SaveChanges();

//var updatedCustomer = db.Customers.Find("BLOGG");
//Console.WriteLine(updatedCustomer);

//var customerToDelete = db.Customers.Find("BLOGG");
//db.Customers.Remove(customerToDelete);
//db.SaveChanges();

//var deleted = db.Customers.Find("BLOGG");
//if (deleted == null) {
//    Console.WriteLine("Deleted Successfully");
//}
//}
#endregion

#region Homework Tasks

// -Read all Trainee's information
//static void ReadAllInfo() {
//    using var db = new NorthwindContext();
//    foreach (var spartan in db.Spartans) {
//        // ToString updated in SpartanExtras file
//        Console.WriteLine(spartan);
//    }
//}

//// - Add some trainees to the database
//static void AddSpartans(List<Spartan> spartanList) {
//    // No checks for if these people are already in the table
//    // so it would just add them again
//    using var db = new NorthwindContext();
//    spartanList.ForEach(s => {
//        Console.WriteLine($"Adding {s.FirstName} {s.LastName} to the Spartans database");
//        db.Spartans.Add(s);
//    });
//    db.SaveChanges();
//}

//// - update a trainee's information
//static void UpdateSpartans(string firstName, string newFirstName) {
//    using var db = new NorthwindContext();
//    // Just get the first person with the name
//    var spartans = db.Spartans.Where(s => s.FirstName == firstName);
//    foreach (var spartan in spartans) {
//        Console.WriteLine($"{spartan.FirstName} {spartan.LastName} (ID: {spartan.PersonId}) " +
//            $"has changed their first name to {newFirstName}");
//        spartan.FirstName = newFirstName;
//    }
//    db.SaveChanges();
//}

//// - delete a trainee (or trainees)
//static void DeleteSpartan(params string[] firstName) {
//    using var db = new NorthwindContext();
//    foreach (var name in firstName) {
//        // Just get 1 person with the name
//        var spartan = db.Spartans.Where(s => s.FirstName == name).FirstOrDefault();
//        if (spartan is not null) {
//            Console.WriteLine($"Deleting {spartan.FirstName} {spartan.LastName} " +
//                                $"(ID: {spartan.PersonId})");
//            db.Spartans.Remove(spartan);
//        }
//    }
//    db.SaveChanges();
//}

//ReadAllInfo();

//var spartanList = new List<Spartan>() {
//    new Spartan() {
//        Title = "Ms.",
//        FirstName = "Kate",
//        LastName = "Nibble",
//    },
//    new Spartan() {
//        Title = "Mr.",
//        FirstName = "David",
//        LastName = "Edgar",
//        Course = "Spanish",
//        UniversityAttended = "Oxford University",
//        Mark = 89
//    }
//};

//AddSpartans(spartanList);

//UpdateSpartans("David", "George");

//DeleteSpartan("George", "David", "Kate");

#endregion

#region LINQ Query Syntax
//using (var db = new NorthwindContext()) {

//var records =
//    from customer in db.Customers
//    select customer;
//foreach (var row in records) {
//    Console.WriteLine(row);
//}

//var londonBerlinQuery1 =
//    from customer in db.Customers
//    where customer.City == "London" || customer.City == "Berlin"
//    select customer;

//foreach (var customer in londonBerlinQuery1) {
//    Console.WriteLine(customer);
//}

//var londonBerlinQuery2 =
//    from customer in db.Customers
//    where customer.City == "London" || customer.City == "Berlin"
//    select new { Customer = customer.ContactName, Country = customer.Country };

//foreach (var customer in londonBerlinQuery2) {
//    Console.WriteLine($"{customer.Customer} lives in {customer.Country}");
//}

//var orderProductsByUnitPrice =
//    from p in db.Products
//    orderby p.UnitPrice descending // default ascending if not specified
//    select p;

//foreach (var product in orderProductsByUnitPrice) {
//    Console.WriteLine($"{product.ProductId} - {product.UnitPrice:C}");
//}

//var groupProductsByUnitInStockQuery =
//    from p in db.Products
//    group p by p.SupplierId into newGroup

//    select new {
//        SupplierID = newGroup.Key,
//        UnitsInStock = newGroup.Sum(c => c.UnitsInStock)
//    };

//foreach (var result in groupProductsByUnitInStockQuery) {
//    Console.WriteLine(result);
//}
//}
#endregion


#region LINQ Method Syntax

//using (var db = new NorthwindContext()) {
//    var query = db.Customers
//        .Where(c => c.City == "London")
//        .OrderBy(c => c.ContactName);
//}



//var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };
//Console.WriteLine(nums.Count(num => num % 2 is 0));
//Console.WriteLine(nums.Count(num => num % 2 is 1));
//Console.WriteLine(nums.Count(num => num <= 4));

//// number cubed is greater than 100
//Console.WriteLine(nums.Count(num => {
//    var numCubed = num * num * num;
//    return numCubed > 100;
//}));



//List<Person> people = new List<Person>
//{
//    new Person { Name = "Fred", Age = 22 },
//    new Person { Name = "Bernard", Age = 35 },
//    new Person { Name = "Margaret", Age = 54 }
//};

//var youngPeople = people.Where(p => p.Age < 30).ToList();
//youngPeople.ForEach(person => Console.WriteLine(person.Name));

//var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };
//Console.WriteLine("Delegate: " + nums.Count(delegate (int n) { return n % 2 == 0; }));
#endregion


#region Method Syntax Task

//using (var db = new NorthwindContext()) {
//var berlinOrLondon = db.Customers
//    .Select(c => new { c.ContactName, c.City })
//    .Where(c => c.City == "London" || c.City == "Berlin");

//foreach (var c in berlinOrLondon) {
//    Console.WriteLine($"{c.ContactName} lives in {c.City}");
//}

//var productsGrouped = db.Products
//    .Select(p => new { p.UnitsInStock, p.SupplierId })
//    .GroupBy(p => p.SupplierId)
//    .Select(p => new {
//        Total = p.Sum(p => p.UnitsInStock),
//        SupplierId = p.Key
//    });

//foreach (var prod in productsGrouped) {
//    Console.WriteLine($"Supplier {prod.SupplierId} has {prod.Total} units in stock");
//}

//var productsOrdered = db.Products
//    .Select(p => new { p.QuantityPerUnit, p.ReorderLevel })
//    .OrderBy(p => p.QuantityPerUnit)
//    .ThenByDescending(p => p.ReorderLevel);

//foreach (var product in productsOrdered) {
//    Console.WriteLine($"{product.QuantityPerUnit} - {product.ReorderLevel}");
//}
//}


#endregion


#region Eager Loading (Includes)
//using (var db = new NorthwindContext()) {
//var orders = db.Orders
//    .Include(o => o.Customer)
//    .Include(o => o.OrderDetails)
//    .Where(o => o.Freight > 750);

//foreach (var order in orders) {
//    if (order.Customer != null)
//        Console.WriteLine($"Order {order.OrderId} " +
//            $"was made by {order.Customer.ContactName} " +
//            $"of {order.Customer.CompanyName}");
//    foreach (var item in order.OrderDetails)
//        Console.WriteLine($"Product: {item.ProductId}, Quantity: {item.Quantity}");
//}

//var orders = db.Orders
//.Include(o => o.Customer)
//.Include(o => o.OrderDetails)
//.ThenInclude(od => od.Product)
//.Where(o => o.Freight > 750)
//.Select(o => o);



//foreach (var order in orders) {
//    Console.WriteLine($"Order {order.OrderId} " +
//            $"was made by {order.Customer.ContactName} " +
//            $"of {order.Customer.CompanyName}");



//    foreach (var od in order.OrderDetails) {
//        Console.WriteLine($"\t Product: {od.ProductId} " +
//            $"- {od.Product.ProductName} " +
//            $"- Quantity {od.Quantity}");
//    }
//}
//}
#endregion

