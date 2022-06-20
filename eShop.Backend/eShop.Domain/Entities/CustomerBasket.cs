using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class CustomerBasket
    {
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
