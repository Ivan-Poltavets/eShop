using eShop.Domain.Entities;
using eShop.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerBasketConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogBrandConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; } 
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<CustomerBasket> CustomerBaskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
