using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CouponAccount.Repository;
using CouponAccount.Models;

namespace CouponAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IConfiguration configuration;
        ICouponRepository couponRepository;
        public CouponController(ICouponRepository couponRepository,IConfiguration configuration)
        {
            this.couponRepository = couponRepository;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("AddCoupon")]
        public IActionResult AddCoupon(CouponDetails coupon)
        {
            try
            {
                couponRepository.AddCoupon(coupon);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCoupon/{couponId}")]
        public IActionResult DeleteCoupon(int couponId)
        {
            try
            {
                couponRepository.DeleteCoupon(couponId);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetCoupons/{userId}")]
        public IActionResult GetCoupons(int userId)
        {
            try
            {
                return Ok(couponRepository.GetAllCoupon(userId));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCoupon")]
        public IActionResult UpdateCoupon(CouponDetails coupon)
        {
            try
            {
                couponRepository.UpdateCoupon(coupon);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("StatusUpdate")]
        public IActionResult Statusupdate()
        {
            try
            {
                couponRepository.Status();
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}