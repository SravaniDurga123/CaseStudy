using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponManagementDBEntity.Repository
{
  public  interface IUserRepository
    {
        void UserRegister(UserDetails user);
        UserDetails UserLogin(string userName, string password);
        void UpdateUser(UserDetails user);
        UserDetails GetUser(int userId);
    }
}
