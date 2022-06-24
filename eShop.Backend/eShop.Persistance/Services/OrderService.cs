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

        public async Task<Order> CreateAsync(OrderDto orderDto, List<OrderItemDto> orderItemDtos)
        {
            int totalPrice = 0;
            foreach(var item in orderItemDtos)
            {
                totalPrice += item.TotalPrice;
            }

            var order = new Order(orderDto.UserId, totalPrice);
            var orderItems = new List<OrderItem>();
            foreach(var item in orderItemDtos)
            {
                orderItems.Add(new OrderItem(item.Name, item.UnitPrice, item.Quantity, item.TotalPrice, order.Id));
            }

            await _context.Orders.AddAsync(order);
            _context.OrderItems.AddRange(orderItems);
            await _context.SaveChangesAsync();

            return order;
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
