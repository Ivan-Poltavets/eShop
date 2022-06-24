namespace eShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; }
        public int TotalPrice { get; set; }

        private Order()
        {

        }

        public Order(List<BasketItem> items, Guid userId)
        {
            Id = Guid.NewGuid();
            Items = items;
            UserId = userId;
            TotalPrice = 0;

            foreach (var item in items)
            {
                TotalPrice += item.TotalPrice;
            }
            
        }
    }
}
