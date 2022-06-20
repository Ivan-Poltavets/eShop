using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Entities
{
    public class CatalogItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureFileName { get; set; }
        public Guid CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public Guid CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
