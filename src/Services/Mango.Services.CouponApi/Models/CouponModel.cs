using Mango.Services.CouponApi.Entity;

namespace Mango.Services.CouponApi.Models
{
    public class CouponModel:ModelBase<Coupon,int>
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
