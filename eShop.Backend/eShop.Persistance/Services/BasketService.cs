﻿using eShop.Application.Dto;
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
        private IHttpContextAccessor _httpContextAccessor;
        public BasketService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BasketItem> AddItem(BasketItemDto basketItemDto)
        {
            var id = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var basket = await GetBasketById(Guid.Parse(id));
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
            return basket;
        }

        public async Task<BasketItem> RemoveItem(BasketItemDto basketItemDto, Guid userId)
        {
            var basket = await GetBasketById(userId);
            var remove = await _context.BasketItems
                .FirstOrDefaultAsync(x => x.CustomerBasketId == basket.Id && x.CatalogItemId == basketItemDto.CatalogItemId);
            _context.Remove(remove);
            await _context.SaveChangesAsync();
            return remove;
        }
    } 
}
