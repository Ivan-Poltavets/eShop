using AutoMapper;
using eShop.Domain.Entities;

namespace eShop.Application.Mappings
{
    public class CatalogMapper : Profile
    {
        public CatalogMapper()
        {
            CreateMap<CatalogItem, CatalogDto>();
        }
    }
}
