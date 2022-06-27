using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IBasketService
    {
        public Task<BasketItem> AddItemAsync(BasketItemDto basketItemDto, Guid userId);
        public Task<BasketItem> RemoveItemAsync(Guid basketItemId, Guid userId);
        public Task<CustomerBasket> GetBasketByIdAsync(Guid userId);
        public Task<List<BasketItem>> GetBasketItemsAsync(Guid userId);
    }
}
