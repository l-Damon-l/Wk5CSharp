namespace SQLWithCSharp;

public class Customer
{
    public string? CustomerID { get; set; }
    public string? CompanyName { get; set; }
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? City { get; set; }

    public string FullName => $"{ContactTitle} - {ContactName}";
}

