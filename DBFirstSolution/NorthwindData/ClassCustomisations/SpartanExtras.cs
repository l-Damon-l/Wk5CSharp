using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData.Models;

public partial class Spartan
{
    public override string ToString() {
        if (this.UniversityAttended is null) {
            return $"{this.Title} {this.FirstName} {this.LastName} didn't go to University";
        }
        return $"{this.Title} {this.FirstName} {this.LastName} Studied {this.Course} " +
                $"at {this.UniversityAttended} and achieved mark of {this.Mark}";
    }
}
