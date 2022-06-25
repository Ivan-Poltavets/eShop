using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreateAsync(OrderDto orderDto, List<OrderItemDto> orderItemDtos);
        public Task<List<Order>> GetOrders(Guid userId);
        public Task<List<OrderItem>> GetOrder(Guid orderId, Guid userId);
        
    }
}
