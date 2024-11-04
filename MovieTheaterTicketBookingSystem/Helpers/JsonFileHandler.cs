using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MovieTheaterTicketBookingSystem.Helpers
{
    public static class JsonFileHandler<T>
    {
        public static List<T> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }

        public static void SaveToFile(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
