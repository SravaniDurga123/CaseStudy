using System;
using System.Collections.Generic;

namespace UserAccount.Models
{
    public partial class CouponDetails
    {
        public int Couponid { get; set; }
        public string Couponno { get; set; }
        public string Status { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int? Userid { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
