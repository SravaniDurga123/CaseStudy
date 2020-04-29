using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponAccount.Models;

namespace CouponAccount.Repository
{
  public  interface ICouponRepository
    {

        List<CouponDetails> GetAllCoupon(int userId);
        void AddCoupon(CouponDetails coupon);
        void UpdateCoupon(CouponDetails coupon);
        void DeleteCoupon(int couponId);
        void Status();

    }
}
