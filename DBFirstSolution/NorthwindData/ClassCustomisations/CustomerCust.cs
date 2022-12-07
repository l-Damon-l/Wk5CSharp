using System;
using System.Collections.Generic;

namespace NorthwindData.Models;

public partial class Customer
{
    public override string ToString() {
        return $"Customer is {CustomerId} - {ContactName} - {CompanyName} - {City}";
    }
}
