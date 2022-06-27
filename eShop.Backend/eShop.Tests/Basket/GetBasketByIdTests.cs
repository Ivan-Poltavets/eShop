using eShop.Persistance.Services;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Tests.Basket
{
    public class GetBasketByIdTests : TestBase
    {
        [Fact]
        public async Task GetBasketById_Success()
        {
            var basketService = new BasketService(Context);
            var basket = basketService.GetBasketByIdAsync(ContextSeed.UserAId);

            Assert.NotNull(await Context.CustomerBaskets.SingleOrDefaultAsync(
                x => x.UserId == ContextSeed.UserAId));
        }

        [Fact]
        public async Task GetBasketById_ExistSuccess()
        {
            var basketService = new BasketService(Context);
            var basket = basketService.GetBasketByIdAsync(ContextSeed.UserBId);

            Assert.NotNull(await Context.CustomerBaskets.SingleOrDefaultAsync(
                x => x.UserId == ContextSeed.UserBId));
        }
    }
}
