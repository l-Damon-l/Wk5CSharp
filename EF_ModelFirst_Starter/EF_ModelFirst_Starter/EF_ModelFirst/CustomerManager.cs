using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    internal class CustomerManager
    {
        private SouthwindContext _db;

        public CustomerManager(SouthwindContext db) {
            _db = db;
        }

        public void Create(Customer customer) {
            try {
                _db.Customers.Add(customer);
                Console.WriteLine($"Customer {customer.ContactName} with ID " +
                    $"{customer.CustomerId} added to context");
                _db.SaveChanges();
            }
            // Already a customer with this ID
            catch (InvalidOperationException) {
                Console.WriteLine($"Customer {customer.ContactName} with ID " +
                    $"{customer.CustomerId} already exists");
            }
        }

        public List<Customer> Read() {
            return _db.Customers.ToList();
        }

        public void Update(Customer customer) {
            // Change the details of customer with the ID
            // of the customer passed in
            var customerToUpdate = _db.Customers.Find(customer.CustomerId);
            if (customerToUpdate is null) {
                Console.WriteLine($"Customer with ID {customer.CustomerId} not found");
                return;
            }
            customerToUpdate.ContactName = customer.ContactName;
            customerToUpdate.City = customer.City;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.PostalCode = customer.PostalCode;
            Console.WriteLine($"Customer {customerToUpdate.ContactName} with ID " +
                $"{customerToUpdate.CustomerId} updated in context");
            _db.SaveChanges();
        }

        public void Delete(string customerId) {
            var customerToDelete = _db.Customers.Find(customerId);
            if (customerToDelete is null) {
                Console.WriteLine($"Customer with ID {customerId} does not exist");
                return;
            }
            _db.Customers.Remove(customerToDelete);
            Console.WriteLine($"Customer {customerToDelete.ContactName} with ID " +
                $"{customerToDelete.CustomerId} deleted from context");
            _db.SaveChanges();
        }
    }
}

