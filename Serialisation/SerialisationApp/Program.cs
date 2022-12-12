using SerialisationApp;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

Trainee trainee = new Trainee {
    FirstName = "Philip",
    LastName = "Windridge",
    SpartaNo = 100
};

Course eng152 = new Course {
    Title = "Engineering 152",
    Subject = "C# Development"
};
eng152.AddTrainee(trainee);
eng152.AddTrainee(
    new Trainee {
        FirstName = "Laura",
        LastName = "Tozer",
        SpartaNo = 1
    });

var serialiser = new SerialiserXml();
var jsonSerialiser = new SerialiserJson();
string fullTraineePath = path + "\\Trainee.xml";
string fullCoursePath = path + "\\Course.xml";
string fullTraineePathJson = path + "\\Trainee.json";
string fullCoursePathJson = path + "\\Course.json";

Serialise(trainee, serialiser, fullTraineePath);
Trainee traineeDeserialisedXML = Deserialise<Trainee>(serialiser, fullTraineePath);

Serialise(eng152, serialiser, fullCoursePath);
Course courseDeserialisedXML = Deserialise<Course>(serialiser, fullCoursePath);

Serialise(trainee, jsonSerialiser, fullTraineePathJson);
Trainee traineeDeserialisedJson = Deserialise<Trainee>(jsonSerialiser, fullTraineePathJson);

Serialise(eng152, jsonSerialiser, fullCoursePathJson);
Course courseDeserialisedJson = Deserialise<Course>(jsonSerialiser, fullCoursePathJson);


static void Serialise<T>(T serialisable, ISerialiser serialiser, string toPath) {
    serialiser.Serialise(serialisable, toPath);
}

static T Deserialise<T>(ISerialiser serialiser, string fromPath) {
    return serialiser.Deserialise<T>(fromPath);
}


Console.WriteLine(traineeDeserialisedXML);
Console.WriteLine(courseDeserialisedXML);
Console.WriteLine(traineeDeserialisedJson);
Console.WriteLine(courseDeserialisedJson);