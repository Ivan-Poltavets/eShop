﻿using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;

        public CatalogService(ApplicationDbContext context) => _context = context;

        public async Task<CatalogBrand> CreateBrand(CatalogBrandDto catalogBrandDto)
        {
            var catalogBrand = new CatalogBrand
            {
                Id = Guid.NewGuid(),
                BrandName = catalogBrandDto.BrandName
            };
            await _context.CatalogBrands.AddAsync(catalogBrand);
            await _context.SaveChangesAsync();
            return catalogBrand;
        }

        public async Task<CatalogItem> CreateItem(CreateCatalogItemDto catalogItemDto)
        {

            var catalogBrand = await FindBrandById(catalogItemDto.CatalogBrandId);
            var catalogType = await FindTypeById(catalogItemDto.CatalogTypeId);

            var catalogItem = new CatalogItem
            {
                Id = Guid.NewGuid(),
                Name = catalogItemDto.Name,
                Description = catalogItemDto.Description,
                Quantity = catalogItemDto.Quantity,
                Price = catalogItemDto.Price,
                CatalogBrandId = catalogItemDto.CatalogBrandId,
                CatalogTypeId = catalogItemDto.CatalogTypeId,
                CatalogBrand = catalogBrand,
                CatalogType = catalogType
            };

            await _context.CatalogItems.AddAsync(catalogItem);
            await _context.SaveChangesAsync();
            return catalogItem;
        }

        public async Task<CatalogType> CreateType(CatalogTypeDto catalogTypeDto)
        {
            var catalogType = new CatalogType
            {
                Id = Guid.NewGuid(),
                TypeName = catalogTypeDto.TypeName
            };
            await _context.CatalogTypes.AddAsync(catalogType);
            await _context.SaveChangesAsync();
            return catalogType;
        }

        public async Task<List<CatalogItem>> GetItemsAsync()
            => await _context.CatalogItems.ToListAsync();

        public async Task<List<CatalogBrand>> GetBrandsAsync()
            => await _context.CatalogBrands.ToListAsync();

        public async Task<List<CatalogType>> GetTypesAsync()
            => await _context.CatalogTypes.ToListAsync();

        public async Task<List<CatalogItem>> GetItemsByName(string name)
        {
            var items = await _context.CatalogItems
                .Where(item => item.Name.StartsWith(name))
                .ToListAsync();

            return items;
        }

        public async Task<List<CatalogItem>> GetItemsByBrand(string brandName)
        {
            var brands = await _context.CatalogBrands
                .Where(brand => brand.BrandName.StartsWith(brandName))
                .ToListAsync();

            var items = new List<CatalogItem>();

            foreach (var brand in brands)
            {
                items.Add(await _context.CatalogItems.FirstOrDefaultAsync(x => x.CatalogBrand == brand));
            }

            return items;
        }

        public async Task<List<CatalogItem>> GetItemsByType(string typeName)
        {
            var types = await _context.CatalogTypes
                .Where(type => type.TypeName.StartsWith(typeName))
                .ToListAsync();

            var items = new List<CatalogItem>();

            foreach (var type in types)
            {
                items.Add(await _context.CatalogItems.FirstOrDefaultAsync(x => x.CatalogType == type));
            }

            return items;
        }


        public async Task<CatalogBrand> FindBrandById(Guid id)
            => await _context.CatalogBrands.FindAsync(id);

        public async Task<CatalogType> FindTypeById(Guid id)
            => await _context.CatalogTypes.FindAsync(id);
    }
}
