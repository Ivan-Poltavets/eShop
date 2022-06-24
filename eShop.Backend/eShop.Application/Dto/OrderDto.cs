using eShop.Domain.Entities;

namespace eShop.Application.Dto
{
    public class OrderDto
    {
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
