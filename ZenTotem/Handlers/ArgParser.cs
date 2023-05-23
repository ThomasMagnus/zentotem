namespace ZenTotem.Handlers
{
    /// <summary>
    /// Класс для парсинга аргументов из командной строки
    /// </summary>
    internal static class ArgParser
    {
        /// <summary>
        /// Метод для парсинга, в качестве параметра принимающий строковый масссив аргумента и возвращающий словарь значений аргументов
        /// </summary>
        /// <param name="argsData">string[] array</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, object> Parser(string[] argsData)
        {
            Dictionary<string, object> argsDict = new Dictionary<string, object>();

            foreach (string item in argsData[1..])
            {
                string[] arrayOnDots = item.Split(':');
                argsDict[arrayOnDots[0]] = arrayOnDots[1];
            }

            return argsDict;
        }
    }
}
