using CouponAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponAccount.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponManagementContext couponManagementContext;
        public CouponRepository(CouponManagementContext couponManagementContext)
        {
            this.couponManagementContext = couponManagementContext;
        }
        public void AddCoupon(CouponDetails coupon)
        {
            couponManagementContext.CouponDetails.Add(coupon);
            couponManagementContext.SaveChanges();
        }

        public void DeleteCoupon(int couponId)
        {
            CouponDetails couponDetails = couponManagementContext.CouponDetails.Find(couponId);
            couponManagementContext.Remove(couponDetails);
            couponManagementContext.SaveChanges();
        }

        public List<CouponDetails> GetAllCoupon(int userId)
        {
            return couponManagementContext.CouponDetails.Where(e => e.Userid == userId).ToList();
        }

        public void Status()
        {
            List<CouponDetails> couponDetails = couponManagementContext.CouponDetails.ToList();
            foreach(var coupon in couponDetails)
            {
                int result = DateTime.Compare(coupon.Enddate, DateTime.Now);
                if(result<0)
                {
                    coupon.Status = "Invalid";
                    couponManagementContext.CouponDetails.Update(coupon);
                    couponManagementContext.SaveChanges();
                }
                else
                {
                    coupon.Status = "valid"; 
                    couponManagementContext.CouponDetails.Update(coupon);
                    couponManagementContext.SaveChanges();
                }
            }
        }

        public void UpdateCoupon(CouponDetails coupon)
        {
            couponManagementContext.CouponDetails.Update(coupon);
            couponManagementContext.SaveChanges();
        }
    }
}
