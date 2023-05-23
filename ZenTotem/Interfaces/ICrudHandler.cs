using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenTotem.Interfaces
{
    internal interface ICrudHandler
    {
        void AddUser(string firstName, string lastName, decimal salaryPerHour);
        void UpdateUser(int id, string userName);
        void GetUser(int id);
        void DeleteUser(int id);
        void GetAllUser();
    }
}
