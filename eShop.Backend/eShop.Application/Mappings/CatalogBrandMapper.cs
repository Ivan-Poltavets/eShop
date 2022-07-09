using AutoMapper;
using eShop.Domain.Entities;

namespace eShop.Application.Mappings
{
    public class CatalogBrandMapper :Profile
    {
        public CatalogBrandMapper()
        {
            CreateMap<CatalogBrandDto, CatalogBrand>();
        }
    }
}
