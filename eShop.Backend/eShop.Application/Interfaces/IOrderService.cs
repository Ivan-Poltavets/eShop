using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreateAsync(OrderDto orderDto, List<OrderItemDto> orderItemDtos);
        public Task<List<Order>> GetOrdersAsync(Guid userId);
        public Task<List<OrderItem>> GetOrderAsync(Guid orderId, Guid userId);
        
    }
}
