using Discount.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.API.Data
{
    public class DiscountContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(DiscountContext)));
        }

        public virtual DbSet<Coupon> Coupons { get; set; }
    }
}
