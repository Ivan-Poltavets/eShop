using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
            => _context = context;

        public async Task<Order> CreateAsync(Guid userId)
        {
            var basketId = (await _context.CustomerBaskets
                .SingleOrDefaultAsync(x => x.UserId == userId))?.Id;

            var items = await _context.BasketItems
                .Where(x => x.CustomerBasketId == basketId)
                .ToListAsync();

            int orderPrice = 0;
            foreach(var item in items)
            {
                orderPrice += item.TotalPrice;
            }

            var order = new Order(userId, orderPrice);
            var orderItems = new List<OrderItem>();
            foreach(var item in items)
            {
                orderItems.Add(new OrderItem(item.CatalogItemId, item.UnitPrice, item.Quantity, item.TotalPrice, order.Id));
            }

            await _context.Orders.AddAsync(order);
            _context.OrderItems.AddRange(orderItems);
            _context.BasketItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            
            return order;
        }

        public async Task<List<OrderItem>> GetOrderAsync(Guid orderId, Guid userId)
        {
            var items = await _context.OrderItems
                .Where(x => x.OrderId == orderId)
                .AsNoTracking()
                .ToListAsync();

            return items;
        }

        public async Task<List<Order>> GetOrdersAsync(Guid userId)
        {
            var orders = await _context.Orders
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
            return orders;
        }
    }
}
