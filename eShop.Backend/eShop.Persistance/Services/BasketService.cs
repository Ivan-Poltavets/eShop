using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance.Services
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;

        public BasketService(ApplicationDbContext context)
            => _context = context;

        public async Task<BasketItem> AddItemAsync(BasketItemDto basketItemDto, Guid userId)
        {
            var basket = await GetBasketByIdAsync(userId);
            var product = await _context.CatalogItems.FirstOrDefaultAsync(x => x.Id == basketItemDto.CatalogItemId);

            var exist = await _context.BasketItems.FirstOrDefaultAsync(x => x.CatalogItemId == basketItemDto.CatalogItemId
            && x.CustomerBasketId == basket.Id);

            if(exist != null)
            {
                exist.Quantity += 1;
                _context.Update(exist);
                _context.SaveChanges();

                return exist;
            }

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

        public async Task<CustomerBasket> GetBasketByIdAsync(Guid userId)
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

        public async Task<BasketItem> RemoveItemAsync(Guid basketItemId, Guid userId)
        {
            var basket = await GetBasketByIdAsync(userId);
            var remove = await _context.BasketItems
                .FirstOrDefaultAsync(x => x.CustomerBasketId == basket.Id && x.Id == basketItemId);
            _context.Remove(remove);
            await _context.SaveChangesAsync();
            return remove;
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync(Guid userId)
        {
            var basket = await GetBasketByIdAsync(userId);
            var items = await _context.BasketItems
                .Where(x => x.CustomerBasketId == basket.Id)
                .ToListAsync();
            return items;
        }
    } 
}
