using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Persistance.EntityTypeConfigurations
{
    public class CustomerBasketConfiguration : IEntityTypeConfiguration<CustomerBasket>
    {
        public void Configure(EntityTypeBuilder<CustomerBasket> builder)
        {
            builder.HasKey(basket => basket.Id);
            builder.HasKey(basket => basket.UserId);
            
        }
    }
}
