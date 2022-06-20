using eShop.Application.Dto;
using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface ICatalogService
    {
        public Task<CatalogBrand> CreateBrand(CatalogBrandDto catalogBrandDto);
        public Task<CatalogType> CreateType(CatalogTypeDto catalogTypeDto);
        public Task<CatalogItem> CreateItem(CreateCatalogItemDto catalogItemDto);

        public Task<List<CatalogItem>> GetItemsAsync();
        public Task<List<CatalogBrand>> GetBrandsAsync();
        public Task<List<CatalogType>> GetTypesAsync();

        public Task<List<CatalogItem>> GetItemsByName(string name);
        public Task<List<CatalogItem>> GetItemsByBrand(string brandName);
        public Task<List<CatalogItem>> GetItemsByType(string typeName);
    }
}
