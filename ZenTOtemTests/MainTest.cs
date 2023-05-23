using ZenTotem;
using ZenTotem.Handlers;

namespace ZenTotemTests
{
    [TestClass]
    public class MainTest
    {
        private List<User>? _userList;

        [TestInitialize]
        public void InitializeData()
        {
            // Инициализация тестовых данных
            _userList = new List<User>()
            {
                new User { Id = 1, FirstName = "John", LastName = "Doe", SalaryPerHour = (decimal)435.12 },
                new User { Id = 2, FirstName = "Jane", LastName = "Smith", SalaryPerHour = (decimal)874.156 },
            };
        }


        [TestMethod]
        public void GetUserByIdTest()
        {
            User? user = UserSearcher.GetUser(2, _userList!);
            Assert.IsNotNull(user);
            Assert.AreEqual("Jane", user?.FirstName);
            Assert.AreEqual("Smith", user?.LastName);
            Assert.AreEqual((decimal)874.156, user?.SalaryPerHour);
        }

        [TestMethod]
        public void GetUserReturnNull()
        {
            User? user = UserSearcher.GetUser(3, _userList!);
            Assert.IsNull(user);
        }
    }
}