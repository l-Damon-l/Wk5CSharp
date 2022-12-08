namespace LinqPractice;

class Student
{
    public string First { get; set; }
    public string Last { get; set; }
    public int ID { get; set; }
    public List<int> Scores;
}

public class Program
{
    public static void Main(string[] args) {
        // Create a data source by using a collection initializer.
        var students = new List<Student> {
        new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
        new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
        new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
        new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
        new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
        new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
        new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
        new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
        new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
        new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
        new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
        new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

        //var studentQuery =
        //    from student in students
        //    where student.Scores.All(score => score >= 80)
        //    orderby student.Last, student.First ascending
        //    select student;

        //foreach (var student in studentQuery) {
        //    Console.WriteLine($"{student.First} {student.Last} achieved 80 or above in every exam ", student.Last, student.First);
        //}

        //Groups students by first letter of last name.
        //var studentQueryGroup =
        //    from student in students
        //    group student by student.Last[0] into studentGroup
        //    // Order last names alphabetically
        //    orderby studentGroup.Key
        //    select studentGroup;

        //foreach (var group in studentQueryGroup) {
        //    Console.WriteLine(Environment.NewLine + new string('-', 25));
        //    Console.WriteLine($"{Environment.NewLine}{group.Key}:{Environment.NewLine}");
        //    foreach (var student in group) {
        //        Console.WriteLine($"   {student.First}, {student.Last}");
        //    }
        //}

        //Introducing 'let' for variables within a Linq query

        var studentQueryLet =
            from student in students
            let totalScore = student.Scores.Sum()
            where totalScore / student.Scores.Count < student.Scores.Average()
            let fullName = student.First + " " + student.Last
            select new { fullName, totalScore };

        foreach (var student in studentQueryLet) {
            Console.WriteLine(student.fullName +
                " has a total score below average (total score of " + student.totalScore + ")");
        }


        // Trying a join query
        //var students2 = new List<Student> {
        //    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60} },
        //    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39} },
        //    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91} },
        //    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70} },
        //    new Student {First="Fred", Last="Garfield", ID=123, Scores= new List<int> {50, 60, 78, 40} }
        //};

        //var studentQueryJoin =
        //    from student in students
        //    join student2 in students2 on student.ID equals student2.ID
        //    select student;

        //foreach (var student in studentQueryJoin) {
        //    Console.WriteLine($"{student.First} {student.Last} with ID: {student.ID} is in both lists");
        //}


        //const char FChar = 'F';
        //var studentQueryWithVar =
        //    from student in students
        //    where student.First.StartsWith(FChar)
        //    select new { student.First, student.Last };

        //foreach (var student in studentQueryWithVar) {
        //    Console.WriteLine($"{student.First} {student.Last} has a first name beginning with {FChar}");
        //}
    }
}
