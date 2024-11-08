using Mango.Framework.Core.Models;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponController(CouponDbContext context) : ControllerBase
    {
        [HttpGet]
        public ResponseApi<List<CouponModel>> Get()
        {
            var res = new ResponseApi<List<CouponModel>>();
            var response = context.Coupons.ToList();
            res.SetSuccess(response.Adapt<List<CouponModel>>(), "");
            return res;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseApi<CouponModel> Get(int id)
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
