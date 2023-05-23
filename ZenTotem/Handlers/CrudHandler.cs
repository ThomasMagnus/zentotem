using ZenTotem.Interfaces;

namespace ZenTotem.Handlers
{
    public class CrudHandler : ICrudHandler
    {
        private readonly JsonReaderHandler? _readerHandler;
        private readonly List<User> _userList;

        public CrudHandler()
        {
            _readerHandler = new JsonReaderHandler("C:\\Users\\emmag\\source\\repos\\ZenTotem\\ZenTotem\\users.json");
            _userList = _readerHandler?.JsonReadText()!;
        }
        public void AddUser(string firstName, string lastName, decimal salaryPerHour)
        {
            int maxId = _userList.Last().Id;

            User user = new User
            {
                Id = ++maxId,
                FirstName = firstName,
                LastName = lastName,
                SalaryPerHour = salaryPerHour
            };

            _userList.Add(user);

            _readerHandler?.JsonWriteText(_userList);

            Console.WriteLine("Пользователь добавлен!");
        }

        public void DeleteUser(int id)
        {

            User? user = UserSearcher.GetUser(id, _userList);

            if (user is null) Console.WriteLine("Пользователь с таким ID не найден!");
            else
            {
                _userList.Remove(user);
                _readerHandler?.JsonWriteText(_userList);

                Console.WriteLine("Пользователь удален!");
            }
        }

        public void GetAllUser()
        {
            if (!_userList.Any()) { Console.WriteLine("Пользователей не найдено!"); }
            else
            {
                foreach (User item in _userList)
                {
                    Console.WriteLine($"Id = {item.FirstName}\n" +
                        $"FirstName = {item.FirstName}\n" +
                        $"LastName = {item.LastName}\n" +
                        $"SalaryPerHour = {item.SalaryPerHour}\n");
                }
            }
        }

        public void GetUser(int id)
        {
            User? user = UserSearcher.GetUser(id, _userList);

            if (user is null) Console.WriteLine("Пользователь с таким ID не найден!");
            else
            {
                Console.WriteLine($"Id = {user.FirstName}\n" +
                    $"FirstName = {user.FirstName}\n" +
                    $"LastName = {user.LastName}\n" +
                    $"SalaryPerHour = {user.SalaryPerHour}\n");
            }
        }

        public void UpdateUser(int id, string userName)
        {
            User? user = UserSearcher.GetUser(id, _userList);

            if (user is null) Console.WriteLine("Пользователь с таким ID не найдем!");
            else
            {
                user.FirstName = userName;
                _readerHandler?.JsonWriteText(_userList);
                Console.WriteLine("Данные перезаписаны!");
            }
        }
    }
}
