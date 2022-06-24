using eShop.Persistance.Services;
using Microsoft.EntityFrameworkCore;

namespace eShop.Tests.Basket
{
    public class RemoveItemTests : TestBase
    {
        [Fact]
        public async Task RemoveItem_Success()
        {
            var basketService = new BasketService(Context);
            Guid catalogItemId = Guid.Parse("4EE0843C-01AB-4B22-888A-9AED92AB12FD");
            var basket = await basketService.GetBasketById(ContextSeed.UserBId);
            await basketService.RemoveItem(catalogItemId, ContextSeed.UserBId);

            Assert.Null(await Context.BasketItems
                .SingleOrDefaultAsync(x => x.CatalogItemId == catalogItemId && x.CustomerBasketId == basket.Id));
        }
    }
}
