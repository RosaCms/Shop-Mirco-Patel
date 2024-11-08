using Mango.Framework.Core.Models;
using Mango.Framework.Models.Coupon.Model;

namespace Mango.Admin.Services.Coupon
{
    public interface ICouponService
    {
        Task<ResponseApi<CouponModel>> GetCouponAsync(string code);
    }
}
