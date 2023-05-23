namespace ZenTotem.Interfaces
{
    internal interface IJsonReaderHandler
    {
        List<User>? JsonReadText();
        public void JsonWriteText(List<User> data);
    }
}
