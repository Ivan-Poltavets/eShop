using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IOrderService
    {
        public Task CreateAsync(OrderDto orderDto);
        public Task<List<Order>> GetOrders(Guid userId);
        public Task<Order> GetOrder(Guid orderId, Guid userId);
        
    }
}
