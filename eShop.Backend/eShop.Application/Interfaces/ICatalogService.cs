using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface ICatalogService
    {
        public Task<CatalogBrand> CreateBrandAsync(CatalogBrandDto catalogBrandDto);
        public Task<CatalogType> CreateTypeAsync(CatalogTypeDto catalogTypeDto);
        public Task<CatalogItem> CreateItemAsync(CreateCatalogItemDto catalogItemDto);

        public Task<List<CatalogItem>> GetItemsAsync();
        public Task<List<CatalogBrand>> GetBrandsAsync();
        public Task<List<CatalogType>> GetTypesAsync();

        public Task<List<CatalogItem>> GetItemsByNameAsync(string name);
        public Task<List<CatalogItem>> GetItemsByBrandAsync(string brandName);
        public Task<List<CatalogItem>> GetItemsByTypeAsync(string typeName);
    }
}
