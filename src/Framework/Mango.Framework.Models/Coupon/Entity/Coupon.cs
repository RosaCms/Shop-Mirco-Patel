
namespace Mango.Framework.Models.Coupon.Entity
{
    public class Coupon : EntityBase
    {
        [Key]
        public int CouponId { get; set; }
        [MaxLength(25)]
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
