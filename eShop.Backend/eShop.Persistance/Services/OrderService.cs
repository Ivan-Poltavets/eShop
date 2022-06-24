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

        public async Task CreateAsync(OrderDto orderDto)
        {
            var order = new Order(orderDto.Items, orderDto.UserId);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(Guid orderId, Guid userId)
        {
            var order = await _context.Orders
                .SingleOrDefaultAsync(x => x.Id == orderId && x.UserId == userId);
            return order;
        }

        public async Task<List<Order>> GetOrders(Guid userId)
        {
            var orders = await _context.Orders
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return orders;
        }
    }
}
