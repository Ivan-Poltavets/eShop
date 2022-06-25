using eShop.Persistance.Services;

namespace eShop.Tests.OrderServices
{
    public class GetOrdersTests : TestBase
    {
        [Fact]
        public async Task GetOrders_Success()
        {
            var orderService = new OrderService(Context);
            var orders = await orderService.GetOrders(ContextSeed.UserAId);

            Assert.NotNull(orders);
        }
    }
}
