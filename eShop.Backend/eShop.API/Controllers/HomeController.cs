﻿using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public HomeController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> Items()
        {
            return Ok(await _catalogService.GetItemsAsync());
        }

        [HttpGet]
        [Route("brands")]
        public async Task<IActionResult> Brands()
        {
            return Ok(await _catalogService.GetBrandsAsync());
        }

        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> Types()
        {
            return Ok(await _catalogService.GetTypesAsync());
        }

        [HttpPost]
        [Route("brands")]
        public async Task<IActionResult> CreateBrand(CatalogBrandDto catalogBrandDto)
        {
            var res = await _catalogService.CreateBrand(catalogBrandDto);
            return CreatedAtAction(nameof(CreateBrand), res);
        }

        [HttpPost]
        [Route("types")]
        public async Task<IActionResult> CreateType(CatalogTypeDto catalogTypeDto)
        {
            var res = await _catalogService.CreateType(catalogTypeDto);
            return CreatedAtAction(nameof(CreateType), res);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateItem(CreateCatalogItemDto catalogItemDto)
        {
            var res = await _catalogService.CreateItem(catalogItemDto);
            return CreatedAtAction(nameof(CreateItem), res);
        }
    }
}
