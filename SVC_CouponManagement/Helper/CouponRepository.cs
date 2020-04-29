using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;

namespace CouponManagment.Helper
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponManagmentContext _context;
        public CouponRepository(CouponManagmentContext context)
        {
            _context = context;
        }
        public void AddCoupon(CouponDetails obj)
        {
            //throw new NotImplementedException();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteCoupon(int couponid)
        {
            //throw new NotImplementedException();
            CouponDetails coupon = _context.CouponDetails.Find(couponid);
            _context.Remove(coupon);
            _context.SaveChanges();
        }

        public List<CouponDetails> GetAllCoupons(int userid)
        {
            //throw new NotImplementedException();
            return _context.CouponDetails.Where(id => id.Userid == userid).ToList();

        }

        public void status()
        {
            List<CouponDetails> c = _context.CouponDetails.ToList();
            foreach (var i in c)
            {
                int res = DateTime.Compare(i.Enddate, DateTime.Now);
                if (res < 0)
                {
                    i.Status = "Invalid";
                    _context.CouponDetails.Update(i);
                    _context.SaveChanges();
                }
                else
                {
                    i.Status = "Valid";
                    _context.CouponDetails.Update(i);
                    _context.SaveChanges();
                }
            }
        }

        public void UpdateCoupon(CouponDetails obj)
        {
            //throw new NotImplementedException();
            _context.CouponDetails.Update(obj);
            _context.SaveChanges();
        }
    }
}

