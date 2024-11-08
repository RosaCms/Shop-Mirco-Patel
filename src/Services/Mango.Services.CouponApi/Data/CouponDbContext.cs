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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "100f",
                DiscountAmount = 10,
                MinAmount = 1000
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "103f",
                DiscountAmount = 15,
                MinAmount = 25000
            });
        }
    }
}
