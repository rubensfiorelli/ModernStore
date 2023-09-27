using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Data.DataContext
{
    public class ModernStoreDataContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }


        public ModernStoreDataContext(DbContextOptions<ModernStoreDataContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<DeliveryAddress>()
                .HasNoKey();

            builder.ApplyConfigurationsFromAssembly(typeof(ModernStoreDataContext).Assembly);

        }




    }
}
