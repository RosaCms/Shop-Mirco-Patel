using Mango.Admin.Services;
using Mango.Admin.Services.Coupon;
using Mango.Framework.Infrastructure.Service;
using Mango.Framework.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;


#region Base Services
services.AddControllersWithViews();
services.AddHttpContextAccessor();
services.AddHttpClient();
#endregion

#region Services
services.AddServicesRoute(configuration);
services.AddHttpClient<ICouponService, CouponService>();
services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
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
