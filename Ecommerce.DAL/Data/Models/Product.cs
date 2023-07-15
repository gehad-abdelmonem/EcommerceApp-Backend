using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }


        public  ProductType? ProductType { get; set; } 
        public ProductBrand? ProductBrand { get; set; }

    }
}
