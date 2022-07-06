namespace eShop.Application.Dto
{
    public class CreateCatalogItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid CatalogBrandId { get; set; }
        public Guid CatalogTypeId { get; set; }
    }
}
