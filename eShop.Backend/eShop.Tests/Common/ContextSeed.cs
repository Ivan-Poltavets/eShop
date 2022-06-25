using eShop.Domain.Entities;
using eShop.Persistance;

namespace eShop.Tests.Common
{
    public class ContextSeed
    {

        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static ApplicationDbContext Seed(ApplicationDbContext context)
        {
            context.CatalogBrands.AddRange(
                new CatalogBrand
                {
                    Id = Guid.Parse("E7FAE64F-9052-46D6-9D65-C9B06E95A666"),
                    BrandName = "Apple"
                },
                new CatalogBrand
                {
                    Id = Guid.Parse("711080F1-8DAE-4E27-85B5-70301DECF9DE"),
                    BrandName = "Microsoft"
                },
                new CatalogBrand
                {
                    Id = Guid.Parse("5F0497B1-5DFD-4306-9DC3-8EDAC08546E0"),
                    BrandName = "Google"
                }
                );

            context.CatalogTypes.AddRange(
                new CatalogType
                {
                    Id = Guid.Parse("84E11EC6-56AE-46B1-A694-AAB67B1BC77C"),
                    TypeName = "Phones"
                },
                new CatalogType
                {
                    Id = Guid.Parse("B7D7B02E-EFC4-4849-ABA5-79811371308A"),
                    TypeName = "OS"
                },
                new CatalogType
                {
                    Id = Guid.Parse("07BF1500-966D-4141-89B4-C522E1B39BFB"),
                    TypeName = "Headphones"
                }
                );

            context.CatalogItems.AddRange(
                new CatalogItem
                {
                    Id = Guid.Parse("4EE0843C-01AB-4B22-888A-9AED92AB12FD"),
                    Name = "Name1",
                    Description = "Description1",
                    Price = 111,
                    Quantity = 1,
                    CatalogBrandId = Guid.Parse("E7FAE64F-9052-46D6-9D65-C9B06E95A666"),
                    CatalogTypeId = Guid.Parse("84E11EC6-56AE-46B1-A694-AAB67B1BC77C")
                },
                new CatalogItem
                {
                    Id = Guid.Parse("91158400-914E-4BCB-A9FD-7866EEB4F282"),
                    Name = "Name2",
                    Description = "Description2",
                    Price = 222,
                    Quantity = 2,
                    CatalogBrandId = Guid.Parse("711080F1-8DAE-4E27-85B5-70301DECF9DE"),
                    CatalogTypeId = Guid.Parse("B7D7B02E-EFC4-4849-ABA5-79811371308A")
                },
                new CatalogItem
                {
                    Id = Guid.Parse("D762D3BF-0CB4-499F-9EC1-E39AB22EC43E"),
                    Name = "Name3",
                    Description = "Description3",
                    Price = 333,
                    Quantity = 3,
                    CatalogBrandId = Guid.Parse("5F0497B1-5DFD-4306-9DC3-8EDAC08546E0"),
                    CatalogTypeId = Guid.Parse("07BF1500-966D-4141-89B4-C522E1B39BFB")
                }
                );

            context.CustomerBaskets.Add(
                new CustomerBasket
                {
                    Id = Guid.Parse("B988A8D3-C9E9-43A0-8164-408F78DEBF5C"),
                    UserId = UserBId
                });

            context.BasketItems.Add(
                new BasketItem
                {
                    Id = Guid.Parse("A0056A6C-FB3C-4BB1-96FE-227A056A7718"),
                    CatalogItemId = Guid.Parse("4EE0843C-01AB-4B22-888A-9AED92AB12FD"),
                    Quantity = 1,
                    UnitPrice = 23,
                    TotalPrice = 23,
                    CustomerBasketId = Guid.Parse("B988A8D3-C9E9-43A0-8164-408F78DEBF5C")
                });

            context.Orders.AddRange(
                new Order
                {
                    Id = Guid.Parse("A453068B-28A2-43B5-96F4-3CA6B0E4980A"),
                    UserId = UserAId,
                    TotalPrice = 11111
                },
                new Order
                {
                    Id = Guid.Parse("41A4E89F-929B-49AC-B3BD-2FFF0D19C160"),
                    UserId = UserAId,
                    TotalPrice = 22222
                }
                );
            context.SaveChanges();
            return context;
        }
    }
}
