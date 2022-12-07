using SQLWithCSharp;
using System.Data.SqlClient;

var customers = new List<Customer>();

using (var connection = new SqlConnection("Data Source=(" +
    "localdb)\\MSSQLLocalDB;" +
    "Initial Catalog=Northwind;" +
    "Integrated Security=True;" +
    "Connect Timeout=30;" +
    "Encrypt=False;" +
    "TrustServerCertificate=False;" +
    "ApplicationIntent=ReadWrite;" +
    "MultiSubnetFailover=False")) {

    connection.Open();
    using (var readCommand = new SqlCommand("SELECT * FROM Customers", connection)) {

        #region Reader
        //SqlDataReader sqlReader = readCommand.ExecuteReader();

        //while (sqlReader.Read()) {
        //    var customer = new Customer {
        //        CustomerID = sqlReader["CustomerId"].ToString(),
        //        ContactName = sqlReader["ContactName"].ToString(),
        //        CompanyName = sqlReader["CompanyName"].ToString(),
        //        City = sqlReader["City"].ToString(),
        //        ContactTitle = sqlReader["ContactTitle"].ToString()
        //    };
        //    customers.Add(customer);
        //}

        //foreach (var customer in customers) {
        //    Console.WriteLine(
        //        $"Customer {customer.FullName} " +
        //        $"has ID {customer.CustomerID} " +
        //        $"and lives in {customer.City}");
        //}

        //sqlReader.Close();
        #endregion

        #region Create
        //var newCustomer = new Customer {
        //    CustomerID = "MO",
        //    ContactName = "Mohammed Dahir",
        //    City = "Birmingham",
        //    CompanyName = "Sparta Global"
        //};

        //var sqlCreateString = $"""
        //    INSERT INTO Customers
        //    (CustomerID, ContactName, CompanyName, City)
        //    VALUES
        //    ('{newCustomer.CustomerID}', 
        //    '{newCustomer.ContactTitle}',
        //    '{newCustomer.ContactName}',
        //    '{newCustomer.CompanyName}')
        //    """;

        //int created;
        //using (var createCommand = new SqlCommand(sqlCreateString, connection)) {
        //    created = createCommand.ExecuteNonQuery();
        //    Console.WriteLine(created);
        //}
        #endregion

        #region Update
        //var sqlUpdateString = """
        //    UPDATE Customers
        //    SET City = 'London'
        //    WHERE CustomerID = 'MO'
        //    """;

        //int updated;
        //using (var createCommand = new SqlCommand(sqlUpdateString, connection)) {
        //    created = createCommand.ExecuteNonQuery();
        //    Console.WriteLine(updated);
        //}
        #endregion

        #region Delete
        //var sqlDeleteString = """
        //    DELETE FROM Customers
        //    WHERE CustomerID = 'MO'
        //    """;

        //int deleted;
        //using (var createCommand = new SqlCommand(sqlDeleteString, connection)) {
        //    deleted = createCommand.ExecuteNonQuery();
        //    Console.WriteLine(deleted);
        //}
        #endregion
    }
}







