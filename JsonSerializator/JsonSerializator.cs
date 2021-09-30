using Serializer.Interfaces;
using System;
using System.IO;
using System.Text.Json;

namespace Serializer
{
    public class JsonSerializator<T> : ISerialize<T>, IDeserialize<T>
    {
        public const string PATH = "RejestrOsobowy.json";

        public void Serialize(T list)
        {
            var data = JsonSerializer.SerializeToUtf8Bytes(list, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllBytes(PATH, data);
        }

        public T Deserialize()
        {
            if (!File.Exists(PATH))
                return (T)(object)null;
            string data = File.ReadAllText(PATH, System.Text.Encoding.UTF8);
            var result = JsonSerializer.Deserialize<T>(data);
            //if (result == null)
            //    throw new Exception("Brak danych w pliku zapisu.");
            return result;
        }
    }
}
