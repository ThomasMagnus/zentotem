using System;
namespace ZenTotem.Handlers
{
    public static class UserSearcher
    {
        public static User? GetUser(int id, List<User> _userList)
        {
            User? user = _userList.FirstOrDefault(x => x.Id == id);

            if (user is null) return null;
            else return user;
        }
    }
}
