namespace eShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int TotalPrice { get; set; }

        private Order()
        {

        }

        public Order(Guid userId, int totalPrice)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            TotalPrice = totalPrice;
        }
    }
}
