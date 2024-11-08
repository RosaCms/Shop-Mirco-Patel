using Mango.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mango.Admin.Services.Coupon;

namespace Mango.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ICouponService couponService)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices]ICouponService couponService)
        {
            var a=couponService.GetAllCouponAsync().Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
