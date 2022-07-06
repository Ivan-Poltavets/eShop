using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Guid userId);
        Task<List<Order>> GetOrdersAsync(Guid userId);
        Task<List<OrderItem>> GetOrderAsync(Guid orderId, Guid userId);
    }
}
