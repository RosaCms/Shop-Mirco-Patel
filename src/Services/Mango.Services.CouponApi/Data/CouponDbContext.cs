using Mango.Services.CouponApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Data
{
    public class CouponDbContext:DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> options):base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
