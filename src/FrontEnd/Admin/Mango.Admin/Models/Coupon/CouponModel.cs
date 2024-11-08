
namespace Mango.Admin.Models.Coupon
{
    public class CouponModel
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
