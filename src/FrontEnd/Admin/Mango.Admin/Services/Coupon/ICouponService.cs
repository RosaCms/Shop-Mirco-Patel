using Mango.Admin.Models.Coupon;
using Mango.Framework.Core.Models;

namespace Mango.Admin.Services.Coupon
{
    public interface ICouponService
    {
        Task<ResponseApi<CouponModel>> GetCouponByIdAsync(int id);
        Task<ResponseApi<List<CouponModel>>> GetAllCouponAsync();
    }
}
