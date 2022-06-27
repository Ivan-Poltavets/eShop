using eShop.Domain.Entities;
using eShop.Persistance.Services;
using Shouldly;

namespace eShop.Tests.OrderServices
{
    public class GetOrderTests : TestBase
    {
        [Fact]
        public async Task GetOrder_Success()
        {
            var orderService = new OrderService(Context);
            var orderId = Guid.Parse("A453068B-28A2-43B5-96F4-3CA6B0E4980A");

            var res = await orderService.GetOrderAsync(orderId, ContextSeed.UserAId);
            Assert.NotNull(res);
            res.Count.ShouldBe(2);
        }
    }
}
