namespace eShop.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public Guid OrderId { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(string name, int unitPrice, int quantity, int totalPrice, Guid orderId)
        {
            Id = Guid.NewGuid();
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
            TotalPrice = totalPrice;
            OrderId = orderId;
        }

    }
}
