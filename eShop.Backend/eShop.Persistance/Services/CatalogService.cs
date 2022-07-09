using AutoMapper;
using eShop.Application.Dto;
using eShop.Application.Interfaces;
using eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CatalogService(ApplicationDbContext context, IMapper mapper) 
            => (_context, _mapper) = (context, mapper);

        public async Task<CatalogBrand> CreateBrandAsync(CatalogBrandDto catalogBrandDto)
        {
            var catalogBrand = _mapper.Map<CatalogBrandDto, CatalogBrand>(catalogBrandDto);

            await _context.CatalogBrands.AddAsync(catalogBrand);
            await _context.SaveChangesAsync();
            return catalogBrand;
        }

        public async Task<CatalogItem> CreateItemAsync(CreateCatalogItemDto catalogItemDto)
        {
            var catalogItem = _mapper.Map<CreateCatalogItemDto, CatalogItem>(catalogItemDto);

            await _context.CatalogItems.AddAsync(catalogItem);
            await _context.SaveChangesAsync();
            return catalogItem;
        }

        public async Task<CatalogType> CreateTypeAsync(CatalogTypeDto catalogTypeDto)
        {
            var catalogType = _mapper.Map<CatalogTypeDto, CatalogType>(catalogTypeDto);

            await _context.CatalogTypes.AddAsync(catalogType);
            await _context.SaveChangesAsync();
            return catalogType;
        }

        public async Task<List<CatalogDto>> GetItemsAsync(int pageSize, int pageIndex)
        {
            var items = await _context.CatalogItems
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
            
            var brands = await _context.CatalogBrands
                .AsNoTracking()
                .ToListAsync();

            var types = await _context.CatalogTypes
                .AsNoTracking()
                .ToListAsync();
            
            var catalogItems = new List<CatalogDto>();
            foreach (var item in items)
            {
                catalogItems.Add(
                    new CatalogDto
                    {
                        BrandName = brands.SingleOrDefault(x => x.Id == item.CatalogBrandId).BrandName,
                        Description = item.Description,
                        ItemName = item.Name,
                        Price = item.Price,
                        TypeName = types.SingleOrDefault(x => x.Id == item.CatalogTypeId).TypeName
                    });
            }

            return catalogItems;
        }

        public async Task<CatalogDto> GetItemById(Guid id)
        {
            var entity = await _context.CatalogItems.FindAsync(id);
            var catalogDto = _mapper.Map<CatalogItem, CatalogDto>(entity);
        
            return catalogDto;
        }

        public async Task<List<CatalogItem>> GetItemsByNameAsync(string name)
        {
            var items = await _context.CatalogItems
                .Where(item => item.Name.StartsWith(name))
                .ToListAsync();

            return items;
        }

        public async Task<List<CatalogItem>> GetItemsByBrandAsync(string brandName)
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

        public async Task<List<CatalogItem>> GetItemsByTypeAsync(string typeName)
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


        public  CatalogBrand FindBrandById(Guid id)
            =>  _context.CatalogBrands.Find(id);

        public  CatalogType FindTypeById(Guid id)
            => _context.CatalogTypes.Find(id);
    }
}
