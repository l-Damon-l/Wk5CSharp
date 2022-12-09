using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    // Doesn't really adhere to DRY/SRP, but good enough for this
    internal class CustomerManagerConsole
    {
        private readonly CustomerManager _customerManager;

        public CustomerManagerConsole(SouthwindContext dbContext) {
            _customerManager = new CustomerManager(dbContext);
        }

        public void MainLoop() {
            UserChoice choice = UserChoice.Initial;
            while (choice is not UserChoice.Exit) {
                choice = GetUserChoice();
                PerformUserChoice(choice);
            }
        }

        private void PerformUserChoice(UserChoice choice) {
            switch (choice) {
                case UserChoice.Create:
                    CreateCustomer();
                    break;
                case UserChoice.Read:
                    ReadCustomers();
                    break;
                case UserChoice.Update:
                    UpdateCustomer();
                    break;
                case UserChoice.Delete:
                    DeleteCustomer();
                    break;
                case UserChoice.Exit:
                    return;
            }
        }

        private UserChoice GetUserChoice() {
            Console.WriteLine("1. Create customer");
            Console.WriteLine("2. Read customers");
            Console.WriteLine("3. Update customer");
            Console.WriteLine("4. Delete customer");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choiceInt = 0;
            while (choiceInt < 1 || choiceInt > 5) {
                string choice = Console.ReadLine();
                bool success = int.TryParse(choice, out choiceInt);
                if (!success || choiceInt < 1 || choiceInt > 5) {
                    Console.WriteLine("Invalid choice");
                    Console.Write("Enter choice: ");
                }
            }
            return (UserChoice)choiceInt;
        }

        private void CreateCustomer() {
            Console.Write("Enter customer ID: ");
            string customerId = Console.ReadLine();
            Console.Write("Enter contact name: ");
            string contactName = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter postal code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter country: ");
            string country = Console.ReadLine();

            var customer = new Customer {
                CustomerId = customerId,
                ContactName = contactName,
                City = city,
                PostalCode = postalCode,
                Country = country
            };
            _customerManager.Create(customer);
        }

        private void ReadCustomers() {
            var customers = _customerManager.Read();
            foreach (var customer in customers) {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.ContactName}, " +
                    $"City: {customer.City} Postcode: {customer.PostalCode} Country: {customer.Country}");
            }
        }

        private void UpdateCustomer() {
            Console.WriteLine("Enter customer ID to update: ");
            var customerId = Console.ReadLine();
            Console.Write("Enter contact name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter postal code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter country: ");
            string country = Console.ReadLine();
            var customer = new Customer {
                CustomerId = customerId,
                ContactName = customerName,
                City = city,
                PostalCode = postalCode,
                Country = country
            };
            _customerManager.Update(customer);
        }

        private void DeleteCustomer() {
            Console.Write("Enter customer ID to delete: ");
            var customerId = Console.ReadLine();
            _customerManager.Delete(customerId);
        }
    }

    internal enum UserChoice
    {
        Initial = 0,
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4,
        Exit = 5
    }
}
