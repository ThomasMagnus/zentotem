using System.Text.Json;
using ZenTotem.Interfaces;

namespace ZenTotem.Handlers
{
    /// <summary>
    /// Класс, предназначенный для чтения JSON из файла
    /// </summary>
    internal class JsonReaderHandler : IJsonReaderHandler
    {
        private string? jsonFilePath;

        public JsonReaderHandler(string jsonFilePath) => this.jsonFilePath = jsonFilePath;

        /// <summary>
        /// Метод для чтения JSON из файла и сериализации
        /// </summary>
        /// <returns>Список пользователей</returns>
        public List<User> JsonReadText()
        {
            string? jsonText = File.ReadAllText(jsonFilePath!);

            List<User>? userList = JsonSerializer.Deserialize<List<User>>(jsonText);

            return userList!;
        }

        /// <summary>
        /// Метод для записи JSON в файл
        /// </summary>
        /// <param name="data">Список пользователей</param>
        public void JsonWriteText(List<User> data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}
