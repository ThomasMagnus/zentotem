using ZenTotem.Interfaces;

namespace ZenTotem.Handlers
{
    /// <summary>
    /// Главный хэндлер, который обрабатывает CRUD API
    /// </summary>
    public class CrudHandler : ICrudHandler
    {
        private readonly JsonReaderHandler? _readerHandler;
        private readonly List<User> _userList;
        private readonly string filePath = Directory.GetCurrentDirectory() + "/users.json";

        public CrudHandler()
        {
            _readerHandler = new JsonReaderHandler(filePath);
            _userList = _readerHandler?.JsonReadText()!;
        }

        /// <summary>
        /// Метод для добавления пользователя
        /// </summary>
        /// <param name="firstName">Имя пользователя: string</param>
        /// <param name="lastName">Фамилия пользователя: string</param>
        /// <param name="salaryPerHour">Оплата за час: decimal</param>
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

        /// <summary>
        /// Метод для удаления пользователя по Id
        /// </summary>
        /// <param name="id">ID пользователя: int</param>
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

        /// <summary>
        /// Метод для вывода всех пользователей
        /// </summary>
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

        /// <summary>
        /// Вывод в консоль пользователя по определенному ID
        /// </summary>
        /// <param name="id">ID пользователя: int</param>
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

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <param name="id">ID пользователя: int</param>
        /// <param name="userName">Имя пользователя: string</param>
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
