using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;
namespace Ordering.Infrastructure.Persistance
{
    public class OrderContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public OrderContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(OrderContext)));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "neel";
                        entry.Entity.LastmodifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "neel";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastmodifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "neel";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Order> Orders { get; set; }

    }
}
