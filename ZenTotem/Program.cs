using ZenTotem.Handlers;

namespace ZenTotem;

internal class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, object> argsDict;
        string mainArg = args[0];
        CrudHandler crudHandler = new CrudHandler();

        try
        {
            switch (mainArg)
            {
                case "-getall":
                    crudHandler.GetAllUser();
                    break;
                case "-add":
                    argsDict = ArgParser.Parser(args);
                    crudHandler.AddUser((string)argsDict["FirstName"], (string)argsDict["LastName"], Convert.ToDecimal(argsDict["Salary"]?.ToString()?.Replace('.', ',')));
                    break;
                case "-update":
                    argsDict = ArgParser.Parser(args);
                    crudHandler.UpdateUser(Convert.ToInt32(argsDict["Id"].ToString()), (string)argsDict["FirstName"]);
                    break;
                case "-get":
                    argsDict = ArgParser.Parser(args);
                    crudHandler.GetUser(Convert.ToInt32(argsDict["Id"].ToString()));
                    break;
                case "-delete":
                    argsDict = ArgParser.Parser(args);
                    crudHandler.DeleteUser(Convert.ToInt32(argsDict["Id"].ToString()));
                    break;
                default:
                    Console.WriteLine("Аргументы не найдены!");
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Вы ввели неверные данные");
        }

    }
}   