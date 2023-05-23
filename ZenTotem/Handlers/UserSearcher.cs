using System;
namespace ZenTotem.Handlers
{
    /// <summary>
    /// Статический класс для возврата пользователей по id
    /// </summary>
    public static class UserSearcher
    {
        /// <summary>
        /// Метод, который находит пользователя по id и возвраящает его
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="_userList">Список пользователей</param>
        /// <returns>User в влучае если пользователь найден, иначе null</returns>
        public static User? GetUser(int id, List<User> _userList)
        {
            User? user = _userList.FirstOrDefault(x => x.Id == id);

            if (user is null) return null;
            else return user;
        }
    }
}
