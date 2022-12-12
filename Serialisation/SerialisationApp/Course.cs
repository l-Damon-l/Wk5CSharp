using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp;

public class Course
{
    public string? Title { get; set; }
    public string? Subject { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>();
    public void AddTrainee(Trainee trainee) {
        Trainees.Add(trainee);
    }
}