namespace eShop.Application.Dto
{
    public class BasketItemDto
    {
        public Guid CatalogItemId { get; set; }
        public Guid CustomerBasketId { get; set; }
        public int Quantity { get; set; }   
    }
}
