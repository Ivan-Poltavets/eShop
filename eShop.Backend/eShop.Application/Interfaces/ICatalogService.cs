using eShop.Domain.Entities;

namespace eShop.Application.Interfaces
{
    public interface ICatalogService
    {
        Task<CatalogBrand> CreateBrandAsync(CatalogBrandDto catalogBrandDto);
        Task<CatalogType> CreateTypeAsync(CatalogTypeDto catalogTypeDto);
        Task<CatalogItem> CreateItemAsync(CreateCatalogItemDto catalogItemDto);

        Task<List<CatalogDto>> GetItemsAsync(int pageSize, int pageIndex);
        Task<CatalogDto> GetItemById(Guid id);

        Task<List<CatalogItem>> GetItemsByNameAsync(string name);
        Task<List<CatalogItem>> GetItemsByBrandAsync(string brandName);
        Task<List<CatalogItem>> GetItemsByTypeAsync(string typeName);
    }
}
