using Mango.Framework.Core.Models;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CouponController(CouponDbContext context) : ControllerBase
    {
        [HttpGet]
        public ResponseApi<string> Get()
        {
            var res = new ResponseApi<string>() { 
            Data="test",
            HasError=false,
            Message="sdfsdf"
            };
            return res;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseApi<CouponModel> Test(int id)
        {
            var res = new ResponseApi<CouponModel>();

            var response=context.Coupons.Find(id);
            
            if (response is null)
                res.SetError("یافت نشد");
            else
                res.SetSuccess(response.Adapt<CouponModel>(),"یافت شد");

            return res;
        }
    }
}
