namespace eShop.Application.Dto
{
    public class OrderItemDto
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
