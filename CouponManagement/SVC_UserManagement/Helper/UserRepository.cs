using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;

namespace UserManagement.Helper
{
    public class UserRepository:IUserRepository
    {
        private readonly CouponManagementContext couponManagementContext;
        public UserRepository(CouponManagementContext couponManagementContext)
        {
            this.couponManagementContext = couponManagementContext;
        }

        public UserDetails GetUser(int userId)
        {
            return couponManagementContext.UserDetails.Find(userId);
        }

        public void UpdateUser(UserDetails user)
        {
            couponManagementContext.UserDetails.Update(user);
            couponManagementContext.SaveChanges();
        }

        public UserDetails UserLogin(string userName, string password)
        {
            UserDetails u1 = couponManagementContext.UserDetails.SingleOrDefault(e => e.Username == userName && e.Password == password);
            return u1;
        }

        public void UserRegister(UserDetails user)
        {
            couponManagementContext.UserDetails.Add(user);
            couponManagementContext.SaveChanges();
        }
    }
}
