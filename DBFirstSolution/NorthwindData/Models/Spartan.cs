using System;
using System.Collections.Generic;

namespace NorthwindData.Models;

public partial class Spartan
{
    public int PersonId { get; set; }

    public string? Title { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UniversityAttended { get; set; }

    public string? Course { get; set; }

    public int? Mark { get; set; }
}
