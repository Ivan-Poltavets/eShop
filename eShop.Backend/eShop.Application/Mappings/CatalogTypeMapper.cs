using AutoMapper;
using eShop.Domain.Entities;

namespace eShop.Application.Mappings
{
    public class CatalogTypeMapper : Profile
    {
        public CatalogTypeMapper()
        {
            CreateMap<CatalogTypeDto, CatalogType>();
        }
    }
}
