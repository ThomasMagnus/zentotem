namespace ZenTotem.Handlers
{
    internal static class ArgParser
    {
        public static Dictionary<string, object> Parser(string[] argsData)
        {
            Dictionary<string, object> argsDict = new Dictionary<string, object>();

            foreach(string item in argsData[1..])
            {
                string[] arrayOnDots = item.Split(':');
                argsDict[arrayOnDots[0]] = arrayOnDots[1];
            }

            return argsDict;
        }
    }
}
