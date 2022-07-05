using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IBasketService
    {
        Task<BasketItem> AddItemAsync(BasketItemDto basketItemDto, Guid userId);
        Task<BasketItem> RemoveItemAsync(Guid basketItemId, Guid userId);
        Task<CustomerBasket> GetBasketByIdAsync(Guid userId);
        Task<List<BasketItem>> GetBasketItemsAsync(Guid userId);
    }
}
