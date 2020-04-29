using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userrepo;
        public UserController(IUserRepository userrepo)
        {
            _userrepo = userrepo;
        }

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(UserDetails value)
        {
            try
            {
                UserDetails u = _userrepo.UserLogin(value.Username, value.Password);
                if (u == null)
                {
                    return Ok("Invalid User");
                }
                else
                    return Ok(u);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        [Route("GetUser/{userid}")]
        public IActionResult GetUser(int userid)
        {
            try
            {

                return Ok(_userrepo.GetUser(userid));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult Post(UserDetails user)
        {
            try
            {
                _userrepo.UserRegister(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }

        }

    }
}