
using eShop.Application.Dto;
using eShop.Domain.Entities;
using eShop.Persistance.Services;
using Microsoft.EntityFrameworkCore;

namespace eShop.Tests.Order
{
    public class CreateOrderTests : TestBase
    {
        [Fact]
        public async Task CreateOrder_Success()
        {
            var orderService = new OrderService(Context);
            Guid userId = ContextSeed.UserBId;
            var basket = await Context.CustomerBaskets
                .SingleOrDefaultAsync(x => x.UserId == userId);

            var basketItems = await Context.BasketItems
                .Where(x => x.CustomerBasketId == basket.Id)
                .ToListAsync();

            var orderItems = new List<OrderItemDto>();

            foreach(var item in basketItems)
            {
                orderItems.Add(new OrderItemDto
                {
                    Name = "sds",
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice
                });
            }

            var orderDto = new OrderDto
            {
                UserId = userId
            };

            var res = await orderService.CreateAsync(orderDto, orderItems);
            Assert.NotNull(await Context.Orders
                .SingleOrDefaultAsync(x => x.UserId == userId && x.Id == res.Id));
            Assert.NotNull(await Context.OrderItems
                .Where(x => x.OrderId == res.Id)
                .ToListAsync());
        }
    }
}
