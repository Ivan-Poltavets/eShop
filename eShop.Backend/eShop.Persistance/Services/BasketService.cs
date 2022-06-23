using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eShop.Persistance.Services
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;
        public BasketService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BasketItem> AddItem(BasketItemDto basketItemDto, Guid userId)
        {
            //var id = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var basket = await GetBasketById(userId);
            var product = await _context.CatalogItems.FirstOrDefaultAsync(x => x.Id == basketItemDto.CatalogItemId);

            var item = new BasketItem
            {
                Id = Guid.NewGuid(),
                Quantity = basketItemDto.Quantity,
                CatalogItemId = basketItemDto.CatalogItemId,
                CustomerBasketId = basket.Id,
                UnitPrice = product.Price,
                TotalPrice = basketItemDto.Quantity * product.Price,
                CustomerBasket = basket
            };

            await _context.BasketItems.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<CustomerBasket> GetBasketById(Guid userId)
        {
            var basket = await _context.CustomerBaskets.FirstOrDefaultAsync(x => x.UserId == userId);
            if(basket == null)
            {
                basket = new CustomerBasket
                {
                    Id = Guid.NewGuid(),
                    UserId = userId
                };
                await _context.CustomerBaskets.AddAsync(basket);
                _context.SaveChanges();
                
            }
            return basket;
        }

        public async Task<BasketItem> RemoveItem(Guid catalogItemId, Guid userId)
        {
            var basket = await GetBasketById(userId);
            var remove = await _context.BasketItems
                .FirstOrDefaultAsync(x => x.CustomerBasketId == basket.Id && x.CatalogItemId == catalogItemId);
            _context.Remove(remove);
            await _context.SaveChangesAsync();
            return remove;
        }
    } 
}
