using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.Extensions.Configuration;

namespace UserManagement.Helper
{
    public class UserRepository : IUserRepository
    {
        private readonly CouponManagmentContext _context;
        private readonly IConfiguration configuration;
        public UserRepository(CouponManagmentContext context,IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
        public UserDetails GetUser(int userid)
        {
            //   throw new NotImplementedException();
            return _context.UserDetails.Find(userid);

        }

        public void UpdateUser(UserDetails user)
        {
            // throw new NotImplementedException();
            _context.UserDetails.Update(user);
            _context.SaveChanges();
        }

        public UserDetails UserLogin(string name, string password)
        {
            // throw new NotImplementedException();
            return _context.UserDetails.SingleOrDefault(e => e.Username == name && e.Password == password);
        }

        public void UserRegister(UserDetails user)
        {
            //throw new NotImplementedException();
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}