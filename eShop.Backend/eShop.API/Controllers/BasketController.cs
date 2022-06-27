using eShop.Application.Dto;
using eShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
            => _basketService = basketService;

        [HttpPost]
        public async Task<IActionResult> AddItem(Guid catalogItemId)
        {
            var basketItemDto = new BasketItemDto
            {
                CatalogItemId = catalogItemId,
                Quantity = 1
            };

            var result = await _basketService.AddItemAsync(basketItemDto, UserId);
            return CreatedAtAction(nameof(AddItem), result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasketItems()
            => Ok(await _basketService.GetBasketItemsAsync(UserId));

        [HttpPost]
        public async Task<IActionResult> RemoveItem(Guid basketItemId)
        {
            await _basketService.RemoveItemAsync(basketItemId, UserId);
            return NoContent();
        }
    }
}
