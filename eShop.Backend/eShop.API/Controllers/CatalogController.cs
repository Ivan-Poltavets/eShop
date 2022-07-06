using eShop.Application.Dto;
using eShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
            => _catalogService = catalogService;

        [HttpGet]
        public async Task<ActionResult<List<CatalogDto>>> GetCatalog(int pageSize = 10, int pageIndex = 0)
            => await _catalogService.GetItemsAsync(pageSize, pageIndex);

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogDto>> GetCatalogItemById(Guid id)
            => await _catalogService.GetItemById(id);

        [HttpPost]
        [Route("brands")]
        public async Task<IActionResult> CreateBrand(CatalogBrandDto catalogBrandDto)
        {
            var res = await _catalogService.CreateBrandAsync(catalogBrandDto);
            return CreatedAtAction(nameof(CreateBrand), res);
        }

        [HttpPost]
        [Route("types")]
        public async Task<IActionResult> CreateType(CatalogTypeDto catalogTypeDto)
        {
            var res = await _catalogService.CreateTypeAsync(catalogTypeDto);
            return CreatedAtAction(nameof(CreateType), res);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateItem(CreateCatalogItemDto catalogItemDto)
        {
            var res = await _catalogService.CreateItemAsync(catalogItemDto);
            return CreatedAtAction(nameof(CreateItem), res);
        }
    }
}
