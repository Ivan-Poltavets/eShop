namespace eShop.Application.Dto
{
    public class CatalogDto
    {
        public string TypeName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
