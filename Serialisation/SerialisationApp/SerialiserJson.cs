using Newtonsoft.Json;

namespace SerialisationApp;

internal class SerialiserJson : ISerialiser
{

    public T Deserialise<T>(string fromPath) {
        string jsonString = File.ReadAllText(fromPath);
        // For the sake of practicing using the null-coalescing operator
        return JsonConvert.DeserializeObject<T>(jsonString)
            ?? throw new Exception("Deserialisation failed");
    }

    public void Serialise<T>(T item, string toPath) {
        string jsonString = JsonConvert.SerializeObject(item);
        File.WriteAllText(toPath, jsonString);
    }
}