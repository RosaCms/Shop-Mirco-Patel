
namespace Mango.Framework.Models.Coupon.Model
{
    public class CouponModel : ModelBase<Entity.Coupon, int>
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
