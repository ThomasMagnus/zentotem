using System.Text.Json;
using ZenTotem.Interfaces;

namespace ZenTotem.Handlers
{
    internal class JsonReaderHandler : IJsonReaderHandler
    {
        private string? jsonFilePath;

        public JsonReaderHandler(string jsonFilePath) => this.jsonFilePath = jsonFilePath;

        public List<User> JsonReadText()
        {
            string? jsonText = File.ReadAllText(jsonFilePath!);

            List<User>? userList = JsonSerializer.Deserialize<List<User>>(jsonText);

            return userList!;
        }

        public void JsonWriteText(List<User> data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}
