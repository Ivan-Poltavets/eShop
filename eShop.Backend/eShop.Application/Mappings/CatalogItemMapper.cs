using AutoMapper;
using eShop.Domain.Entities;

namespace eShop.Application.Mappings
{
    public class CatalogItemMapper : Profile
    {
        public CatalogItemMapper()
        {
            CreateMap<CreateCatalogItemDto, CatalogItem>();
        }
    }
}
