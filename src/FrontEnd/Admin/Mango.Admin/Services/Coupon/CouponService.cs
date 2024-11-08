using Mango.Admin.Models.Coupon;
using Mango.Admin.Utility;
using Mango.Framework.Core.Enums;
using Mango.Framework.Core.Models;
using Mango.Framework.Infrastructure.Service;


namespace Mango.Admin.Services.Coupon
{
    public class CouponService(IBaseService baseService): ICouponService
    {

        public async Task<ResponseApi<CouponModel>> GetCouponByIdAsync(int id)
        {
            var data = await baseService.SendAsync<CouponModel>(new RequestApi()
            {
                ApiType = ApiTypeEnum.GET,
                Url = UrlServices.CouponApi+"/"+id,
                Data = new CouponModel()

            });
            return data;
        }

        public async Task<ResponseApi<List<CouponModel>>> GetAllCouponAsync()
        {
            var data = await baseService.SendAsync<List<CouponModel>>(new RequestApi()
            {
                ApiType = ApiTypeEnum.GET,
                Url = UrlServices.CouponApi 
            });

            return data;
        }
    }
}
