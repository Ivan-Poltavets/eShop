using eShop.Application.Dto;
using eShop.Persistance.Services;
using Microsoft.EntityFrameworkCore;

namespace eShop.Tests.Basket
{
    public class AddItemTests : TestBase
    {
        [Fact]
        public async Task AddItem_Success()
        {
            var basketService = new BasketService(Context);
            Guid catalogItemId = Guid.Parse("91158400-914E-4BCB-A9FD-7866EEB4F282");

            var basketItemDto = new BasketItemDto
            {
                CatalogItemId = catalogItemId,
                Quantity = 1
            };
            var result = await basketService.AddItem(basketItemDto, ContextSeed.UserBId);
            Assert.NotNull(await Context.BasketItems
                .SingleOrDefaultAsync(x => x.CatalogItemId == result.CatalogItemId && x.Quantity == result.Quantity
                && x.CustomerBasketId == result.CustomerBasketId));
        }
    }
}
