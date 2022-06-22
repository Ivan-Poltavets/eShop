using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface IBasketService
    {
        public Task<BasketItem> AddItem(BasketItemDto basketItemDto);
        public Task<BasketItem> RemoveItem(BasketItemDto basketItemDto, Guid userId);
        public Task<CustomerBasket> GetBasketById(Guid userId);
    }
}
