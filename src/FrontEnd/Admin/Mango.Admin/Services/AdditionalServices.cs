using Mango.Admin.Utility;

namespace Mango.Admin.Services
{
    public static class AdditionalServices
    {
        public static void AddServicesRoute(this IServiceCollection services,IConfiguration configuration)
        {
            UrlServices.CouponApi = configuration.GetValue<string>("ServiceUrls:CouponUrl") ?? "";
        }
        
    }
}
