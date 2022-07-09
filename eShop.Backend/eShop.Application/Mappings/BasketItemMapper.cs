using AutoMapper;
using eShop.Domain.Entities;

namespace eShop.Application.Mappings
{
    public class BasketItemMapper : Profile
    {
        public BasketItemMapper()
        {
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
