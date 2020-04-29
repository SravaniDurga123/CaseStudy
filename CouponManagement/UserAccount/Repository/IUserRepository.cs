using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccount.Models;
namespace UserAccount.Repository
{
   public interface IUserRepository
    {

        void UserRegister(UserDetails user);
        UserDetails UserLogin(string userName, string password);
        void UpdateUser(UserDetails user);
        UserDetails GetUser(int userId);
    }
}
