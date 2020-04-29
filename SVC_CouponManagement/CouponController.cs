using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CouponManagment
{
    [Route("api/[controller]")]
    public class CouponController : ControllerBase
    {
        public class UserRepository : IUserRepository
        {
            private readonly CouponManagmentContext _context;
            public UserRepository(CouponManagmentContext context)
            {
                _context = context;
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
}
