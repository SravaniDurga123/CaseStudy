﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        IUserRepository userRepository;
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult UserRegister(UserDetails user)
        {
            try
            {
                userRepository.UserRegister(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(UserDetails value)
        {
            try
            {
                UserDetails userDetails = userRepository.UserLogin(value.Username, value.Password);
                if (userDetails == null)
                    return Ok("Invalid");
                else
                    return Ok("Valid user");

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetUser/{userId}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                return Ok(userRepository.GetUser(userId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UserDetails user)
        {
            try
            {
                userRepository.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
