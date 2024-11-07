using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponApi.Entity
{
    public class Coupon:EntityBase
    {
        public int CouponId { get; set; }
        [MaxLength(25)]
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
