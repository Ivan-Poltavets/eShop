using eShop.Application.Dto;
using eShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
            => _basketService = basketService;

        [HttpPost]
        [Route("items")]
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
        [Route("items")]
        public async Task<IActionResult> GetAllBasketItems()
            => Ok(await _basketService.GetBasketItemsAsync(UserId));

        [HttpDelete]
        [Route("items")]
        public async Task<IActionResult> RemoveItem(Guid basketItemId)
        {
            await _basketService.RemoveItemAsync(basketItemId, UserId);
            return NoContent();
        }
    }
}
