using Ecommerce.BL.Dtos.ProductBrand;
using Ecommerce.BL.Dtos.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Product
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public ReadBrandDto ProductBrand { get; set; } = new();
        public ReadTypeDto ProductType { get; set; } = new();
    }
}
