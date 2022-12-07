// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
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
static void ReadAllInfo() {
    using var db = new NorthwindContext();
    foreach (var spartan in db.Spartans) {
        // ToString updated in SpartanExtras file
        Console.WriteLine(spartan);
    }
}

// - Add some trainees to the database
static void AddSpartans(List<Spartan> spartanList) {
    // No checks for if these people are already in the table
    // so it would just add them again
    using var db = new NorthwindContext();
    spartanList.ForEach(s => {
        Console.WriteLine($"Adding {s.FirstName} {s.LastName} to the Spartans database");
        db.Spartans.Add(s);
    });
    db.SaveChanges();
}

// - update a trainee's information
static void UpdateSpartans(string firstName, string newFirstName) {
    using var db = new NorthwindContext();
    // Just get the first person with the name
    var spartans = db.Spartans.Where(s => s.FirstName == firstName);
    foreach (var spartan in spartans) {
        Console.WriteLine($"{spartan.FirstName} {spartan.LastName} (ID: {spartan.PersonId}) " +
            $"has changed their first name to {newFirstName}");
        spartan.FirstName = newFirstName;
    }
    db.SaveChanges();
}

// - delete a trainee (or trainees)
static void DeleteSpartan(params string[] firstName) {
    using var db = new NorthwindContext();
    foreach (var name in firstName) {
        // Just get 1 person with the name
        var spartan = db.Spartans.Where(s => s.FirstName == name).FirstOrDefault();
        if (spartan is not null) {
            Console.WriteLine($"Deleting {spartan.FirstName} {spartan.LastName} " +
                                $"(ID: {spartan.PersonId})");
            db.Spartans.Remove(spartan);
        }
    }
    db.SaveChanges();
}

ReadAllInfo();

var spartanList = new List<Spartan>() {
    new Spartan() {
        Title = "Ms.",
        FirstName = "Kate",
        LastName = "Nibble",
    },
    new Spartan() {
        Title = "Mr.",
        FirstName = "David",
        LastName = "Edgar",
        Course = "Spanish",
        UniversityAttended = "Oxford University",
        Mark = 89
    }
};

AddSpartans(spartanList);

UpdateSpartans("David", "George");

DeleteSpartan("George", "David", "Kate");

#endregion