using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Guid CatalogItemId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public Guid CustomerBasketId { get; set; }
        public CustomerBasket CustomerBasket { get; set; }
    }
}
