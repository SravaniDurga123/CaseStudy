using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponManagementDBEntity.Repository
{
   public interface IUserRepository
    {
        UserDetails UserLogin(string name, string password);

        void UserRegister(UserDetails user);
        void UpdateUser(UserDetails user);
        UserDetails GetUser(int userid);
    }
}
