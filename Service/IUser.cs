using CRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Service
{
    public interface IUser
    {
         bool AddUser(UserModel user);
        List<UserModel> GetAllUsers();
        bool UpdateUser(UserModel user);
        bool DeleteUser(int Id);
    }
}
