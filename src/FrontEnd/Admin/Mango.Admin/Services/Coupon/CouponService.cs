using Mango.Framework.Core.Models;
using Mango.Framework.Models.Coupon.Model;

namespace Mango.Admin.Services.Coupon
{
    public class CouponService: ICouponService
    {
        public Task<ResponseApi<CouponModel>> GetCouponAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
