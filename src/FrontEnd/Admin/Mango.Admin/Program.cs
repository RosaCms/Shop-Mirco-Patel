using System.Globalization;
using Mango.Admin.Services;
using Mango.Admin.Services.Coupon;
using Mango.Framework.Infrastructure.Service;
using Mango.Framework.Web.Services;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;


#region Base Services
services.AddControllersWithViews();
services.AddHttpContextAccessor();
services.AddHttpClient();
services.AddLocalization(x => x.ResourcesPath = "Resources");
services.AddScoped<IBaseService, Class>();
services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("fa-IR"),
        new CultureInfo("en-US"),
    };

    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "fa-IR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

});
#endregion

#region Services
services.AddServicesRoute(configuration);
services.AddHttpClient<ICouponService, CouponService>();

services.AddScoped<ICouponService, CouponService>();
#endregion

var app = builder.Build();

#region App
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

#endregion

#region Routes

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
