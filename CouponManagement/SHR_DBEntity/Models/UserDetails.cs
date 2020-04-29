using System;
using System.Collections.Generic;

namespace CouponManagementDBEntity.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            CouponDetails = new HashSet<CouponDetails>();
        }

        public int Userid { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public string Mobile { get; set; }
        public DateTime? Registeredtime { get; set; }

        public virtual ICollection<CouponDetails> CouponDetails { get; set; }
    }
}
